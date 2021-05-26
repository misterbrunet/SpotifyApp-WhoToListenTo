from flask import jsonify
import pandas as pd #IMPORTANT TO IMPORT PANDAS
from pandas import Series
import pyodbc
import json
import re

#Init SQL connection  via WINDOWS AUTHENTICATION
Server = r'KOMPUTER\MSSQLSERVER01'   #sql username
Database = 'SpotifyDataSQL' #database name
Driver = 'ODBC Driver 17 for SQL Server' #ODBC driver (search for odbc in windows > then drivers)
Database_con = f'mssql://@{Server}/{Database}?driver={Driver}'

#engine = sql.create_engine(Database_con,{})
#con = engine.connect()

con = pyodbc.connect(f'DRIVER={Driver};SERVER={Server};Database={Database};TRUSTED_CONNECTION=yes')
cursor = con.cursor()


def find_artist(artist):   
    print(f"podany artysta: {artist}")
    id_art = ReturnArtistID(artist)
    print(f"\n zwrocone id artysty: {TrimText(str(id_art))}")
    similar_ids = FindArtistJson(TrimText(str(id_art)))
    names = ReturnNamesFromSimArtIDs(similar_ids)
    print(names)
    print(type(names))
    return names.to_json(orient="records")#jsonify(names)

def FindArtistJson(id_art):
	art_similar_dict = []
	with open(r"D:\DATA_DEV\spotify_data_fixed\dict_artists.json", 'r') as json_data:
            data = json.loads(json_data.read())#, strict=False)
            #art_similar_dict = [val for key, val in data.items() if id_art in key]
            if id_art in data.keys():
                #print(data[id_art])
                art_similar_dict.append(data[id_art])                      
            #if id_art in data[1]:
                #art_similar_dict = data[1]
            print(art_similar_dict)
            return art_similar_dict

def ReturnArtistID(name):
    cursor.execute(f"Select artists.artistID From artists where artists.artist_name='{name}'")
    id_art = cursor.fetchall()
    return id_art

def TrimText(name):
    start = chr(39)
    end = chr(39)
    result = re.search('%s(.*)%s'%(start,end), name).group(1)
    return result

def ReturnNamesFromSimArtIDs(l = []):
    ll = l[0]
    placeholders = ','.join('?' for i in range(len(ll)))  # '?,?'
    sqlq = "Select artists.artist_name From artists where artists.artistID in (%s)" % placeholders
    df = pd.read_sql(sqlq, con, params=ll)
    return df


idd = 'Eminem'
find_artist(idd)













































