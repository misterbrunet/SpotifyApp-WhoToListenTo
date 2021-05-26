# SpotifyApp-WhoToListenTo
App I made for a school project. It uses C# as a frontend user app, Python's FLASK api as a backend and a SQL server as a database.

## Main Goals of the project:
- Connect to the SQL DB
- Use API as a backend mechanism
- Write working C# frontend application using WPF
- Design user-friendly UI
- Try to protect program from an error-crashing
- Complete all the teacher's tasks for an A grade

## What's that about?
The app itself gives a user a feedback on who to listen to on Spotify based on artist's name  given by them.
Second option is to give some artist's name with an additional name (or just a substring) of a song produced by given artist, which
would return data about one or many songs. The data contains 5 key values such as valence, tempo, daceability, loudness and energy
which give more details about user's taste in music.
I wanted to also add an option to review past years based on Spotify data in terms of key values (similar to 5 given above but way more), but
I didn't finish it. Propably I'll add in the future.

##### The whole project was a real pleasure for me, because I felt like I was doing something that I like: both music and programming.



#### Setting up Flask
You need to make sure that you have Python enviroment installed on your PC. Version I used was 3.9.5. 
By simple **pip install** you can download via cmd window all the needed packages. You can see al the 
packeges that I used at the top of my .py script.

To get you Flask API running, you need to open up cmd window, go to the folder where you stashed flask script.
(for me it was c:\Python\Python395\SpotifyApi)
After that, you'll need to set a system variable for FLASK_APP and you do it by simple writing:
***set FLASK_APP=yourFlaskAppScript.py***            in your cmd.

You could set pernament env variable in your computer, but while working with several projects such as this one
I prefer setting it everytime I need it. That so I don't have to remember which flask project I'm currently running.

Also set debug mode (while in development for better and easier changes) if you want to test and develop your flask api in action.
To do so you need to set another variable (this could be a pernament one) in your cmd:
***set FLASK_DEBUG=1***

here's a cool video from Corey Shafer about making first steps in Python's Flask:
https://www.youtube.com/watch?v=MwZwr5Tvyxo

If it's all set, then you could start Flask running in the background by typing simple ***Flask run*** in your cmd window.
From now on it's running in the debug mode, so that if you add changes to the Flask file .py, then by pressing "save button"
they will be immediately added and flask api will restart instantly by itself.

#### C# APP
As I said - C# plays a role of a frontend app, but that's not completly true. It has Spotify black-green UI on top, but also
a powerful, but simple backend mechanism which allows to comunicate with the API, by sending GET requests and reciving 
serialized Json objects as answers. It can both process recived data and display the answers in a proper way.
I made special effort to try to make it dummy-proof both on C# app's side and the API's side. 

#### SQL DATABSE
The whole operation of building a seperate database was not hard. Nor it should be for you. The hardest thing was to prepare 
the data in a proper way, so that the DB would read it and wouldn't have to store unnecessary Megabytes of data.

After Jupyter notebook playground work I was able to trim the data in the desired manner. Also I was able to seperate 
tangled primary keys which were three, four or more in one cell, so that the DB would have a problem matching them
in a query.

#### Project Background
My goal was simple at first: I needed an wpf app to complete my semester and I had to implement all of the requirements to get A grade.
The app itself was meant to be able to connect to SQL, retrive data, add, delete etc. I had to implement async functions, own events and some
animations using e.graphics. So it doesn't sound hard, but I wanted to do something extra.
Some time ago my friend told me about ***Kaggle*** website, which offers a lot of ready to work with datasets - but prepared in a way,
that Python would be the main programming language to work with.
And then I had an idea to make an SQL DB based on historical data from Spotify from last 100 years.
(here's the link: https://www.kaggle.com/yamaerenay/spotify-dataset-19212020-160k-tracks)

The first problem was how big and not optimalized this data actually is for a data foundation in SQL.
Although there are values that could be used as primary keys in DB tables, are often stacked together in one data cell, e.i.:
- artistID are put together in one cell if one song has multiple artists singing in it (features)
- JSON file has nested recomended artists based on their IDs but has 250Mb of size
- there is too much unnecessary data for me to work on.

So for the beggining I had to write some scripts that would trim the .cvs files in a way, that I found useful.
Python Jupiter notebooks came handy. I had to delete some data and split some of the rows into two or three seperate (but duplicated) rows
with only one artist ID per row, so that it'd be possbile to join tables in the SQL DB.

After that I used BULK INSERT with adequate parameters to populate already prepared DB tables with my fresh data.
I used Postman to test different connections to the API and slowly improve the API's structure.
In the meantime I was writing C# application with UI based on Spotify theme. 

I had to implement some additional features completly not related to the topic, but in order to pass with an A grade I needed to do something
about it. That's why there a second Form nested in "other" section which uses **BasicItemSQL.cs**. Basic class needed to implement operation
on SQL DB such as add or delete item, because main goal was only about search and retrive data based on given name of an artist or song.
