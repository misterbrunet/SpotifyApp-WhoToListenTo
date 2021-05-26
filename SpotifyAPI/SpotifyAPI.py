from flask import Flask, jsonify
import pyodbc
import pandas as pd
import json
import re

#init Flask app
app = Flask(__name__)

# let's use the flask in debug mode
if __name__ == '__main__':
    app.run(debug=True)

##############################################################################
#   Init SQL connection  via WINDOWS AUTHENTICATION
#
Server = r'KOMPUTER\MSSQLSERVER01'                                #sql username
Database = 'SpotifyDataSQL'                                       #database name
Driver = 'ODBC Driver 17 for SQL Server'                          #ODBC driver (search for odbc in windows > then drivers)
Database_con = f'mssql://@{Server}/{Database}?driver={Driver}'    #complete connection string 

# Create adequate connection to given SQL DB
con = pyodbc.connect(f'DRIVER={Driver};SERVER={Server};Database={Database};TRUSTED_CONNECTION=yes')

# create object responsible for executing SQL aueries (there are two methods used in this flask app - one from pydobc (cursor) and second from pandas)
cursor = con.cursor()

#######################################################################
#   ARTIST SEARCH
#
@app.route("/artist/<artist>", methods=['GET'])
def find_artist(artist):  
    
                                                        # 1) returns matching artistID from SQL DB
    id_art = ReturnArtistID(artist) 
    if len(id_art) == 0:
        return jsonify(jdata_artist_name)    
    
                                                        # 2) returns matching similar artists' IDs from JSON file
    similar_ids = FindArtistJson(TrimText(str(id_art)))
    if len(similar_ids) == 0:
        return jsonify(jdata_artist_no_sim)
    
                                                        # 3) returns matching similar artists' NAMES from SQL DB
    try:
        names = ReturnNamesFromSimArtIDs(similar_ids)
        if len(names)  == 0:
            return jsonify(jdata_artist_no_sim)
    except:
        return jsonify(jdata_artist_no_sim)
    
                                                        # 4) launching proper data (if exists)
    return PrepareJsonToLaunch(names)


#######################################################################
#   SONG SEARCH
#
@app.route("/song/<artist>/<song>", methods=['GET'])
def find_song(artist,song):
                                                        # 1) check if initial values are correct
    if len(song) == 0 or len(artist) == 0:              #    return error if such occurs
        return JsonResponseERROR()
                                                        # 2) Execute query based on given values and retrive them
    song_data = ReturnSongsWithDetails(artist, song)   
                                                        # 3) check if returned values even exist. If not - return error JSON
    if song_data.empty:
        return JsonResponseERROR()
                                                        # 4) Launch proper data if everything checks out
    return PrepareJsonToLaunch(song_data)


######################################################################
#   FUNCTIONS
#

##   finds matching similar artists based on given artistID in JSON file
def FindArtistJson(id_art):
	art_similar_dict = []                              # 1) init empty list
    
                                                       # 2) open stored JSON file
	with open(r"D:\DATA_DEV\spotify_data_fixed\dict_artists.json", 'r') as json_data:
        
            data = json.loads(json_data.read())        # 3) load it to new JSON formatted object
            
            if id_art in data.keys():                  # 4) go through it, while searching for a matching artistID
                        
                art_similar_dict.append(data[id_art])  # 5) if it finds it, copy all the values from the found artistID key                      
            
            return art_similar_dict                    # 6) return found data
 
        
##   finds given artist's name matching ID
def ReturnArtistID(name):
                                                       # 1) search in SQL matching artistID to given artist_name
    cursor.execute(f"Select artists.artistID From artists where artists.artist_name='{name}'")
                                                       # 2) retrive query's response 
    id_art = cursor.fetchall()
    return id_art                                      # 3) return found artistID 


##   trims recived name from SQL to proper form
def TrimText(name):
    start = chr(39)                                    # 1) set start and end of trimming string at ' symbol (unicode = 39) 
    end = chr(39)
    result = re.search('%s(.*)%s'%(start,end), name).group(1)
    return result                                      # 2) return freshly trimmed string 


##   prepares and returns similar artists' names based on given array of IDs
def ReturnNamesFromSimArtIDs(l = []):
                                                       # 1) this strange looking indexing is necessary, because data from the JSON is being retrived 
    ll = l[0]                                          #    as a list of lists, while having only one list with all the similar artists' IDs at index = 0 
    
                                                       # 2) seperate and retrive a new list with only artist IDs in it 
    placeholders = ','.join('?' for i in range(len(ll)))  # '?,?'
    
                                                       # 3) Execute ONE query which will find matching artist_names for given list of IDs 
    sqlq = "Select artists.artist_name From artists where artists.artistID in (%s)" % placeholders
                                                       # 4) load 'em 
    df = pd.read_sql(sqlq, con, params=ll)

    return df                                          # 5) send 'em


##   prepares given data in proper format to send from API
def PrepareJsonToLaunch(data):
                                                       # 1) start preparing new JSON dataframe
    data_temp =  data.to_json(orient="records")
                                                       # 2) load prepared JSON dataframe into real JSON-oriented object
    parsed = json.loads(data_temp)
                                                       # 3) return ready to go JSON object 
    return json.dumps(parsed, indent = 4)   


##  returns dataframe with song's features for given Artist's name
def ReturnSongsWithDetails(artist, song = ""):
                                                       # 1) prepare query string 
    sqlq = f"Select name,artist,danceability,energy,loudness,valence,tempo From tracks where tracks.artist = '{artist}' and name like '%{song}%'"
                                                       # 2) use pandas to execute the query 
    df = pd.read_sql(sqlq, con)
                                                       # 3) return retrived dataframe 
    return df


##  Gives basic JSON object feedback if action was successful
def JsonResponseOK():
    return jsonify(name = "success")


##  Gives basic JSON object feedback if action was failed
def JsonResponseERROR():
    return jsonify(name = "error")


#####################################################################
#   ADDING OR DELETING DATA FROM SQL
#
##   Retrives all the BasicItems from the SQL if successes, JSONerror message if fails
@app.route("/basicitemssql", methods=['GET'])
def DisplayAllBasicItemsSQL():
    try:                                               # 0) try-except block is much safer than nothing
                                                       # 1) use pandas to execute basic query in SQL to retrive dataframe 
        df = pd.read_sql("Select * from user_action",con)

        return PrepareJsonToLaunch(df)                 # 2) if everything's ok, then JSON file is being prepared and launched back 
    except:                                            # 3) if try block throws an except, functions returns JSONerror  
        return JsonResponseERROR()

## adds BasicItem to the SQL DB with the parameters given in the URL
@app.route("/basicitemssql/<name1>/<number1>", methods=['GET'])
def AddBasicItemSQL(name1,number1):
    try:                                               # 0) try-except block is much safer than nothing
                                                       # 1) use pyodbc to execute basic query in SQL to retrive dataframe 
        cursor.execute(f"insert into user_action (name,number) values ('{name1}',{number1})")
                                                       # 2) VERY IMPORTANT: using pydobc remember to close session by executing 'commit' after executing the query.
                                                       #    If not, the SQL will freeze all the incoming transactions 
        cursor.execute("commit")                    
                                                       # 3) return JSONsuccess if the proces goes correctly 
        return JsonResponseOK()
    except:                                            # 4) return JSONerror if the proces fails  
        return JsonResponseERROR()

## deletes BasicItem from the SQL DB with the parameters given in the URL
@app.route("/basicitemssql/delete/<name1>/<number1>", methods=['GET'])
def DeleteBasicItemSQL(name1,number1):
    try:                                               # 0) try-except block is much safer than nothing
                                                       # 1) use pyodbc to execute basic query in SQL to retrive dataframe 
        cursor.execute(f"Delete from user_action where name = '{name1}' and number = {number1}")
                                                       # 2) VERY IMPORTANT: using pydobc remember to close session by executing 'commit' after executing the query.
        cursor.execute("commit")
                                                       # 3) return JSONsuccess if the proces goes correctly
        return JsonResponseOK()
    except:                                            # 4) return JSONerror if the proces fails
        return JsonResponseERROR()


##########################################################
#   test route
@app.route("/json", methods=['GET'])
def multi_json():
    return jsonify(jdata_test) 


    
#########################################################
# Some basic test routes
@app.route("/")
@app.route("/home")
def home():
    return "<h1>Home Page</h1>"

@app.route("/name/<name>")
def hi_name(name):
    return 'Hello %s' % name


@app.route("/data", methods=['GET'])
def return_json():
    return jsonify({'result' : 'success', 'x':'100'})









#    JSON message templates
jdata_test = [
  {
    "fname": "Kent",
    "lname": "Brockman",
    "timestamp": "2018-05-10 18:12:42"
  },
  {
    "fname": "Bunny",
    "lname": "Easter",
    "timestamp": "2018-05-10 18:12:42"
  },
  {
    "fname": "Doug",
    "lname": "Farrell",
    "timestamp": "2018-05-10 18:12:42"
  }
]

jdata_artist_name = [{"artist_name" : "there is no author with given name. Try again.","number":"0"}]
jdata_artist_no_sim = [{"artist_name" : "there are no suggested artists for the one given. Try again","number":"0"}]
jdata_wrong_info_song = [{"name" : "there is no author with given name. Try again.","number":"0"}]
addItemError = [{"name":"there was a problem adding an item to the database"}]
addItemSuccess = [{"name":"success","number":"1"}]
deleteItemError = [{"name":"there was a problem removing one item from the database","number":"0"}]


