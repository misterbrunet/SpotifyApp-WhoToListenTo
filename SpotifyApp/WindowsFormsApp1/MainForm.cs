using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WhoToListenTo
{
    public partial class MainFormWindow : Form
    {
        #region Variables
        AnimatedObject Img;                           //Image for animation
        APIrequests APIreq = new APIrequests();       //APIrequest Menager
        System.Drawing.Color selectedButtonColor = System.Drawing.Color.FromArgb(92, 96, 99);   //
        System.Drawing.Color defaultButtonColor = System.Drawing.Color.FromArgb(61, 48, 48);    //Custom Colors
        System.Drawing.Color BlackSColor = System.Drawing.Color.FromArgb(25, 20, 20);           //
        Button previousButton;                        //Object reffering previously cliked button
        bool shouldDraw;                              //Indicates if animation should occur
        int TextBoxWidth = 70;                             //width of the main textBox
        string guide_text =                           //Text with info about app itself
 @"
Welcome to WhoToListenTo 

By cliking >>Search by artist<< you will retrieve 
similar artists on Spotify to one given by you.

By cliking >>Search by song<< you will retrieve 
statistics based on 5 key values which will help 
you get to know more of what vibes are you into.

By cliking >>Year stats<< you will retrieve data
showing how music was changing throughout 100 years
(not available in beta)

By clicking >>Show other<< you will see two more functions
which are necessery for me to pass a grade with the maximum points.
";
        string[] art_resp_m = {
            "Be sure to check'em out!",
            "Pff, I know better artists",
            "Holy cow, is it 2004 or something?",
            "Woah! You must like Ed Sheeran very much, don't you?",
            "Finally some good music",
            "Psst...Spotify for students costs the same as cigarettes",
            "God bless I don't save search history",
            "Should I be worried?",
            "PoLskA GurOm, przejmujemy spotifaj!",
            "Taco used to be better",
            "I wish i had some emoticons for u"       
        };                    //Custom messages shown after searching for artist/song
        #endregion

        public MainFormWindow()
        {         
            InitializeComponent();
            APIHandler.InitializeClient();                  //initialize Object responsible for preparing API requests      
            Timer.Start();                                  //Start timer needed for the animation
            APIreq.NewError += APIreq_NewError;             //Raising an event each time form validates - based on delegate
            textBox_main.Text += guide_text;                //Welcome form text
            textBox_main.Visible = true;                    
        }

        #region Delegate prop
        /// <summary>
        /// Displays proper error message based on a source of a problem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APIreq_NewError(object sender, string e)
        {
            switch (e)
            {
                case "errorArtist":
                    textBox_main.Text += "There was a problem with given artist. \n\nCheck if the name is written correctly.\n" +
                  "\nIf the name's right, then there might be a couple of artists with the same name.";
                    break;
                case "errorSong":
                    textBox_main.Text += "There was a problem with given artist and song name.\n\nCheck if Artist name is written correctly and retry\n" +
                        "or make sure that given Song name (or part of it) is correct and may exist.\n\nThere might be no data about given song name.";
                    break;
                default:
                    textBox_main.Text += "Something went wrong.";
                    break;
            }       
        }
        #endregion

        #region ButtonClicks
        /// <summary>
        /// Hides unnecessary buttons and clears already written texts. Displays needed things to search for Artist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_artist_Click(object sender, EventArgs e)
        {            
            if (!textBox_main.Visible || previousButton == button_guide || previousButton == null) ShowSearchBoxes();
            HideSong();
            IsHiddenOther();
            IsInfoShowed();
            HighlightButton((Button)sender);
            ClearPanelTag();
            textBox_song.Clear();
        }
        /// <summary>
        /// Hides unnecessary buttons and clears already written texts. Displays needed things to search for Artist and
        /// given song name (or part of it)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_song_Click(object sender, EventArgs e)
        {          
            if (!textBox_main.Visible) ShowSearchBoxes();
            IsHiddenOther();
            IsInfoShowed();
            ShowSong();
            ClearPanelTag();
            HighlightButton((Button)sender);
        }
        /// <summary>
        /// Prepares Form for displaying statistics per 100 years based on Spotify Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_years_Click(object sender, EventArgs e)
        {
            IsHiddenOther();
            HideSearchBoxes();
            IsInfoShowed();
            ClearPanelTag();
            HighlightButton((Button)sender);
        }
        /// <summary>
        /// Hides unrelated tools and reveals two additional buttons: 'Draw Image' and 'SQL'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_other_Click(object sender, EventArgs e)
        {
            if (textBox_main.Visible) HideSearchBoxes();
            button_drawObject.Visible = true;
            button_SQL.Visible = true;
            IsInfoShowed();
            ClearPanelTag();
            HighlightButton((Button)sender);
        }
        /// <summary>
        /// Initializes an animation of a Spotify Logo shown as a falling bouncy ball.
        /// Each click resets the animation. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_drawObject_Click(object sender, EventArgs e)
        {
            
            HighlightButton((Button)sender);
            ClearPanelTag();
            shouldDraw = true;
            CreateAnimatedObject();
        }
                                                                   
        private void button_guide_Click(object sender, EventArgs e)
        {
            ClearPanelTag();
            IsHiddenOther();
            HideSearchBoxes();
            textBox_main.Visible = true;           
            textBox_main.Text = guide_text;
            HighlightButton((Button)sender);
        }
        /// <summary>
        /// Initializes adequate HTTPS sequence based on chosen action (search for Artist or Song name)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_SEARCH_Click(object sender, EventArgs e)
        {
            if (previousButton == button_artist)
            {
                if (textBox_artist.Text.Length > 0)
                {
                    string artist = textBox_artist.Text;
                    this.UseWaitCursor = true;
                    await LoadDataArtist(artist);
                }
                else
                {
                    textBox_main.Text = "Fill the necessary fields, please";
                }
            }
            else if (previousButton == button_song)
            {
                if (textBox_artist.Text.Length > 0 && textBox_song.Text.Length > 0)
                {
                    string artist = textBox_artist.Text;
                    string song = textBox_song.Text;
                    this.UseWaitCursor = true;
                    await LoadDataSong(artist, song);
                }
                else
                {
                    textBox_main.Text = "Fill the necessary fields, please.\n Songname should have one char at least.";
                }
            }
        }
        /// <summary>
        /// Initializes a new Form in a dialog mode, which enables additionas modifications in SQL DB 
        /// such as ADD or DELETE an item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SQL_Click(object sender, EventArgs e)
        {
            if (textBox_main.Visible) HideSearchBoxes();
            IsInfoShowed();
            ClearPanelTag();
            HighlightButton((Button)sender);
            PopUpForm form = new PopUpForm();
            form.ShowDialog();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Shows main components used in displaying searched data
        /// </summary>
        private void ShowSearchBoxes()
        {
            textBox_main.Visible = true;
            textBox_artist.Visible = true;
            button_SEARCH.Visible = true;
            label_artist.Visible = true;
            ClearPanelTag();
        }
        /// <summary>
        /// Hides components responsible for writing song information
        /// </summary>
        private void HideSong()
        {
            label_song.Visible = false;
            textBox_song.Visible = false;
            ClearPanelTag();
        }
        /// <summary>
        /// Displays components responsible for writing song information
        /// </summary>
        private void ShowSong()
        {
            label_song.Visible = true;
            textBox_song.Visible = true;
        }
        /// <summary>
        /// Hides main components used in showing searched data
        /// </summary>
        private void HideSearchBoxes()
        {
            textBox_main.Visible = false;
            textBox_artist.Visible = false;
            button_SEARCH.Visible = false;
            label_artist.Visible = false;
            textBox_song.Clear();
            textBox_artist.Clear();
            textBox_main.Clear();
            HideSong();
            ClearPanelTag();
        }
        /// <summary>
        /// Hides 'other' section if is not hidden
        /// </summary>
        private void IsHiddenOther()
        {
            if(button_drawObject.Visible)
            {
                button_drawObject.Visible = false;
                button_SQL.Visible = false;
                shouldDraw = false;
                Img = null;
            }
        }
        /// <summary>
        /// if textBox_main contains written instructions, becomes cleared
        /// </summary>
        private void IsInfoShowed()
        {
            textBox_main.Text = null;
        }
        /// <summary>
        /// Highlights button if clicked. Saves reference to cliked button.
        /// </summary>
        /// <param name="sender">Clicked button becames 'previousButton'</param>
        private void HighlightButton(Button sender)
        {
            if (previousButton != null )
            {
                previousButton.BackColor = defaultButtonColor;
            }
            previousButton = sender;
            sender.BackColor = selectedButtonColor;
        }
        /// <summary>
        /// Clears panel_song 
        /// </summary>
        private void ClearPanelTag()
        {
            label_SongTags.Text = " ";
        }
        /// <summary>
        /// Chooses random message from preset stack of messages from art_resp_m
        /// </summary>
        /// <returns></returns>
        private string ChooseMessage()
        {
            Random r = new Random();
            int num = r.Next(0,art_resp_m.Length+1);
            return art_resp_m[num];
        }
        /// <summary>
        /// Creates brand new AnimatedObject into Img variable
        /// </summary>
        private void CreateAnimatedObject()
        {           
            Img = new AnimatedObject();
            Img.X = panel_Logo.Width / 2f;
            Img.BottomLevel = panel_Logo.Height;
        }
        /// <summary>
        /// Enables using button_search by simply pressing enter while button is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SEARCH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button_SEARCH_Click(sender, e);
        }
        #endregion

        #region Animation
        /// <summary>
        /// Causes invalidation each time one tick passes. If bool shouldDraw is true, enables process 
        /// responsible for accurate math operations based on a direction in which the Image should be going: up or down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (shouldDraw)
            {
                if (Img.Direction == "fall")
                {                  
                        Img.ProperFall();                                    
                }
                else 
                {
                    Img.Bounce();
                }
            }
            panel_Logo.Invalidate();
        }
        /// <summary>
        /// If bool shouldDraw is true, displays current position of the Image. If is false - makes sure the panel is black. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Logo_Paint(object sender, PaintEventArgs e)
        {
            if (shouldDraw)
            {
                Img.Draw(e.Graphics);
            }
            else e.Graphics.Clear(BlackSColor);
        }
        #endregion

        #region APIrequests
        /// <summary>
        /// Async function responsible for displaying returned values about similar Artists to one given by user.
        /// If process fails then displays to user that there was a problem.
        /// </summary>
        /// <param name="artist">Main Artist name</param>
        /// <returns></returns>
        private async Task LoadDataArtist(string artist)
        {
            List<Artist> art = new List<Artist>();
            art = await APIreq.LoadDataArtist(artist);
            if (textBox_main.Text.Length > 0) textBox_main.Clear();
            int rk = 1;    //index
            foreach (Artist a in art)
            {
                textBox_main.Text += "\t" + rk++.ToString() + ". " + a.artist_name + "\n";
            }
            textBox_main.Text += $"\n\n{ChooseMessage()}";
            UseWaitCursor = false;
        }
        /// <summary>
        /// Async function responsible for displaying given artist's songs with its key factors.
        /// </summary>
        /// <param name="artist">Searched Artist</param>
        /// <param name="song">string or substring correlated to a name of one  or many artist's songs</param>
        /// <returns></returns>
        private async Task LoadDataSong(string artist, string song)
        {
            List<Song> sg = new List<Song>();
            sg = await APIreq.LoadDataSong(artist, song);
            if (sg.Count !=0)
            {
                if (textBox_main.Text.Length > 0) textBox_main.Clear();
                label_SongTags.Text = "name|danceability   energy        valence      loudness      tempo";         
                List<Song> uniqueSongs = new List<Song>();
                foreach (Song s1 in sg)                     //Display only uniqe songs from those retrived from API
                {
                    bool duplicatefound = false;
                    foreach (Song s2 in uniqueSongs)
                    {
                        if (s1.name == s2.name) duplicatefound = true;
                    }                   
                    if (!duplicatefound) uniqueSongs.Add(s1);
                }
                foreach (Song s in uniqueSongs)
                {
                    textBox_main.Text += (s.name+" ").PadRight(TextBoxWidth,'-') + "\n\t" + s.danceability + "\t\t" + s.energy + "\t\t" + s.valence + "\t\t" + s.loudness + "\t\t" + s.tempo + "\n\n";
                }            
            }
            UseWaitCursor = false;
        }
        #endregion

        #region TextBoxes - TEXT
        /// <summary>
        /// Blocks the possibility of a cursor entering textBox_main Text. User cannot highlight the text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_main_Enter(object sender, EventArgs e)
        {
            textBox_main.Enabled = false;
            textBox_main.Enabled = true;
        }
        /// <summary>
        /// If textBox_artist is cliked, clears textBox_main/artists/song (and).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_artist_Click(object sender, EventArgs e)
        {
            textBox_main.Clear();
            if (textBox_artist.Text.Length > 0) textBox_artist.Clear();
            textBox_song.Clear();
        }
        /// <summary>
        /// If textBox_song is cliked, clears textBox_main/song (and)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_song_Click(object sender, EventArgs e)
        {
            textBox_main.Clear();
            textBox_song.Clear();
        }
        #endregion

    }
}
