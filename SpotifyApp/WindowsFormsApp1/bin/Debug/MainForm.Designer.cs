
namespace WhoToListenTo
{
    partial class MainFormWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.button_SQL = new System.Windows.Forms.Button();
            this.panel_Logo = new System.Windows.Forms.Panel();
            this.button_guide = new System.Windows.Forms.Button();
            this.button_drawObject = new System.Windows.Forms.Button();
            this.button_other = new System.Windows.Forms.Button();
            this.button_years = new System.Windows.Forms.Button();
            this.button_song = new System.Windows.Forms.Button();
            this.button_artist = new System.Windows.Forms.Button();
            this.lgroundPanel = new System.Windows.Forms.Panel();
            this.ltopPanel = new System.Windows.Forms.Panel();
            this.lleftPanel = new System.Windows.Forms.Panel();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.groundPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label_SongTags = new System.Windows.Forms.Label();
            this.label_song = new System.Windows.Forms.Label();
            this.textBox_song = new System.Windows.Forms.TextBox();
            this.label_artist = new System.Windows.Forms.Label();
            this.textBox_main = new System.Windows.Forms.RichTextBox();
            this.button_SEARCH = new System.Windows.Forms.Button();
            this.textBox_artist = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.leftPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.leftPanel.Controls.Add(this.button_SQL);
            this.leftPanel.Controls.Add(this.panel_Logo);
            this.leftPanel.Controls.Add(this.button_guide);
            this.leftPanel.Controls.Add(this.button_drawObject);
            this.leftPanel.Controls.Add(this.button_other);
            this.leftPanel.Controls.Add(this.button_years);
            this.leftPanel.Controls.Add(this.button_song);
            this.leftPanel.Controls.Add(this.button_artist);
            this.leftPanel.Controls.Add(this.lgroundPanel);
            this.leftPanel.Controls.Add(this.ltopPanel);
            this.leftPanel.Controls.Add(this.lleftPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(188, 441);
            this.leftPanel.TabIndex = 0;
            // 
            // button_SQL
            // 
            this.button_SQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_SQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_SQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SQL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_SQL.Location = new System.Drawing.Point(123, 139);
            this.button_SQL.Margin = new System.Windows.Forms.Padding(0);
            this.button_SQL.Name = "button_SQL";
            this.button_SQL.Size = new System.Drawing.Size(54, 23);
            this.button_SQL.TabIndex = 13;
            this.button_SQL.TabStop = false;
            this.button_SQL.Text = "SQL";
            this.button_SQL.UseVisualStyleBackColor = false;
            this.button_SQL.Visible = false;
            this.button_SQL.Click += new System.EventHandler(this.button_SQL_Click);
            // 
            // panel_Logo
            // 
            this.panel_Logo.BackColor = System.Drawing.Color.Transparent;
            this.panel_Logo.ForeColor = System.Drawing.Color.Transparent;
            this.panel_Logo.Location = new System.Drawing.Point(22, 162);
            this.panel_Logo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Logo.Name = "panel_Logo";
            this.panel_Logo.Size = new System.Drawing.Size(155, 235);
            this.panel_Logo.TabIndex = 12;
            this.panel_Logo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Logo_Paint);
            // 
            // button_guide
            // 
            this.button_guide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_guide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_guide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_guide.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_guide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_guide.Location = new System.Drawing.Point(22, 400);
            this.button_guide.Margin = new System.Windows.Forms.Padding(0);
            this.button_guide.Name = "button_guide";
            this.button_guide.Size = new System.Drawing.Size(155, 23);
            this.button_guide.TabIndex = 11;
            this.button_guide.TabStop = false;
            this.button_guide.Text = "Guide";
            this.button_guide.UseVisualStyleBackColor = false;
            this.button_guide.Click += new System.EventHandler(this.button_guide_Click);
            // 
            // button_drawObject
            // 
            this.button_drawObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_drawObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_drawObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_drawObject.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_drawObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_drawObject.Location = new System.Drawing.Point(22, 139);
            this.button_drawObject.Margin = new System.Windows.Forms.Padding(0);
            this.button_drawObject.Name = "button_drawObject";
            this.button_drawObject.Size = new System.Drawing.Size(96, 23);
            this.button_drawObject.TabIndex = 10;
            this.button_drawObject.TabStop = false;
            this.button_drawObject.Text = "Draw object";
            this.button_drawObject.UseVisualStyleBackColor = false;
            this.button_drawObject.Visible = false;
            this.button_drawObject.Click += new System.EventHandler(this.button_drawObject_Click);
            // 
            // button_other
            // 
            this.button_other.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_other.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_other.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_other.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_other.Location = new System.Drawing.Point(22, 110);
            this.button_other.Margin = new System.Windows.Forms.Padding(0);
            this.button_other.Name = "button_other";
            this.button_other.Size = new System.Drawing.Size(155, 23);
            this.button_other.TabIndex = 9;
            this.button_other.TabStop = false;
            this.button_other.Text = "Show more ";
            this.button_other.UseVisualStyleBackColor = false;
            this.button_other.Click += new System.EventHandler(this.button_other_Click);
            // 
            // button_years
            // 
            this.button_years.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_years.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_years.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_years.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_years.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_years.Location = new System.Drawing.Point(22, 81);
            this.button_years.Margin = new System.Windows.Forms.Padding(0);
            this.button_years.Name = "button_years";
            this.button_years.Size = new System.Drawing.Size(155, 23);
            this.button_years.TabIndex = 8;
            this.button_years.TabStop = false;
            this.button_years.Text = "Year stats (soon)";
            this.button_years.UseVisualStyleBackColor = false;
            this.button_years.Click += new System.EventHandler(this.button_years_Click);
            // 
            // button_song
            // 
            this.button_song.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_song.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_song.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_song.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_song.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_song.Location = new System.Drawing.Point(22, 52);
            this.button_song.Margin = new System.Windows.Forms.Padding(0);
            this.button_song.Name = "button_song";
            this.button_song.Size = new System.Drawing.Size(155, 23);
            this.button_song.TabIndex = 7;
            this.button_song.TabStop = false;
            this.button_song.Text = "Search by song";
            this.button_song.UseVisualStyleBackColor = false;
            this.button_song.Click += new System.EventHandler(this.button_song_Click);
            // 
            // button_artist
            // 
            this.button_artist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_artist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_artist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_artist.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_artist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_artist.Location = new System.Drawing.Point(22, 23);
            this.button_artist.Margin = new System.Windows.Forms.Padding(0);
            this.button_artist.Name = "button_artist";
            this.button_artist.Size = new System.Drawing.Size(155, 23);
            this.button_artist.TabIndex = 6;
            this.button_artist.TabStop = false;
            this.button_artist.Text = "Search by artist";
            this.button_artist.UseVisualStyleBackColor = false;
            this.button_artist.Click += new System.EventHandler(this.button_artist_Click);
            // 
            // lgroundPanel
            // 
            this.lgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lgroundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lgroundPanel.Location = new System.Drawing.Point(5, 436);
            this.lgroundPanel.Name = "lgroundPanel";
            this.lgroundPanel.Size = new System.Drawing.Size(183, 5);
            this.lgroundPanel.TabIndex = 2;
            // 
            // ltopPanel
            // 
            this.ltopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.ltopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ltopPanel.Location = new System.Drawing.Point(5, 0);
            this.ltopPanel.Name = "ltopPanel";
            this.ltopPanel.Size = new System.Drawing.Size(183, 5);
            this.ltopPanel.TabIndex = 1;
            // 
            // lleftPanel
            // 
            this.lleftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lleftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lleftPanel.Location = new System.Drawing.Point(0, 0);
            this.lleftPanel.Name = "lleftPanel";
            this.lleftPanel.Size = new System.Drawing.Size(5, 441);
            this.lleftPanel.TabIndex = 0;
            // 
            // middlePanel
            // 
            this.middlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.middlePanel.Location = new System.Drawing.Point(188, 0);
            this.middlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(5, 441);
            this.middlePanel.TabIndex = 1;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(193, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(591, 5);
            this.topPanel.TabIndex = 2;
            // 
            // groundPanel
            // 
            this.groundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.groundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groundPanel.Location = new System.Drawing.Point(193, 436);
            this.groundPanel.Name = "groundPanel";
            this.groundPanel.Size = new System.Drawing.Size(591, 5);
            this.groundPanel.TabIndex = 3;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(779, 5);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(5, 431);
            this.rightPanel.TabIndex = 4;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mainPanel.Controls.Add(this.label_SongTags);
            this.mainPanel.Controls.Add(this.label_song);
            this.mainPanel.Controls.Add(this.textBox_song);
            this.mainPanel.Controls.Add(this.label_artist);
            this.mainPanel.Controls.Add(this.textBox_main);
            this.mainPanel.Controls.Add(this.button_SEARCH);
            this.mainPanel.Controls.Add(this.textBox_artist);
            this.mainPanel.Location = new System.Drawing.Point(193, 5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(586, 433);
            this.mainPanel.TabIndex = 5;
            // 
            // label_SongTags
            // 
            this.label_SongTags.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_SongTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(215)))), ((int)(((byte)(170)))));
            this.label_SongTags.Location = new System.Drawing.Point(26, 75);
            this.label_SongTags.Name = "label_SongTags";
            this.label_SongTags.Size = new System.Drawing.Size(528, 20);
            this.label_SongTags.TabIndex = 301;
            // 
            // label_song
            // 
            this.label_song.AutoSize = true;
            this.label_song.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_song.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.label_song.Location = new System.Drawing.Point(73, 42);
            this.label_song.Name = "label_song";
            this.label_song.Size = new System.Drawing.Size(70, 14);
            this.label_song.TabIndex = 15;
            this.label_song.Text = "song name";
            this.label_song.Visible = false;
            // 
            // textBox_song
            // 
            this.textBox_song.BackColor = System.Drawing.Color.LightGray;
            this.textBox_song.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_song.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_song.ForeColor = System.Drawing.Color.Red;
            this.textBox_song.Location = new System.Drawing.Point(146, 41);
            this.textBox_song.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_song.MaxLength = 150;
            this.textBox_song.Name = "textBox_song";
            this.textBox_song.Size = new System.Drawing.Size(201, 22);
            this.textBox_song.TabIndex = 11;
            this.textBox_song.Visible = false;
            this.textBox_song.WordWrap = false;
            this.textBox_song.Click += new System.EventHandler(this.textBox_song_Click);
            // 
            // label_artist
            // 
            this.label_artist.AutoSize = true;
            this.label_artist.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_artist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.label_artist.Location = new System.Drawing.Point(94, 17);
            this.label_artist.Name = "label_artist";
            this.label_artist.Size = new System.Drawing.Size(49, 14);
            this.label_artist.TabIndex = 13;
            this.label_artist.Text = "artist";
            this.label_artist.Visible = false;
            // 
            // textBox_main
            // 
            this.textBox_main.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.textBox_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_main.CausesValidation = false;
            this.textBox_main.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_main.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_main.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.textBox_main.Location = new System.Drawing.Point(29, 95);
            this.textBox_main.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_main.Name = "textBox_main";
            this.textBox_main.ReadOnly = true;
            this.textBox_main.Size = new System.Drawing.Size(525, 323);
            this.textBox_main.TabIndex = 300;
            this.textBox_main.TabStop = false;
            this.textBox_main.Text = "";
            this.textBox_main.Visible = false;
            this.textBox_main.Enter += new System.EventHandler(this.textBox_main_Enter);
            // 
            // button_SEARCH
            // 
            this.button_SEARCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.button_SEARCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_SEARCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SEARCH.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SEARCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.button_SEARCH.Location = new System.Drawing.Point(363, 13);
            this.button_SEARCH.Margin = new System.Windows.Forms.Padding(0);
            this.button_SEARCH.Name = "button_SEARCH";
            this.button_SEARCH.Size = new System.Drawing.Size(61, 23);
            this.button_SEARCH.TabIndex = 14;
            this.button_SEARCH.Text = "Search";
            this.button_SEARCH.UseVisualStyleBackColor = false;
            this.button_SEARCH.Visible = false;
            this.button_SEARCH.Click += new System.EventHandler(this.button_SEARCH_Click);
            this.button_SEARCH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_SEARCH_KeyDown);
            // 
            // textBox_artist
            // 
            this.textBox_artist.BackColor = System.Drawing.Color.LightGray;
            this.textBox_artist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_artist.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_artist.ForeColor = System.Drawing.Color.Red;
            this.textBox_artist.Location = new System.Drawing.Point(146, 16);
            this.textBox_artist.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_artist.MaxLength = 150;
            this.textBox_artist.Name = "textBox_artist";
            this.textBox_artist.Size = new System.Drawing.Size(201, 22);
            this.textBox_artist.TabIndex = 0;
            this.textBox_artist.Visible = false;
            this.textBox_artist.WordWrap = false;
            this.textBox_artist.Click += new System.EventHandler(this.textBox_artist_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 24;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.groundPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.leftPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainFormWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhoToListenTo";
            this.leftPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel groundPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel lgroundPanel;
        private System.Windows.Forms.Panel ltopPanel;
        private System.Windows.Forms.Panel lleftPanel;
        private System.Windows.Forms.Button button_artist;
        private System.Windows.Forms.Button button_drawObject;
        private System.Windows.Forms.Button button_other;
        private System.Windows.Forms.Button button_years;
        private System.Windows.Forms.Button button_song;
        private System.Windows.Forms.RichTextBox textBox_main;
        private System.Windows.Forms.Button button_SEARCH;
        private System.Windows.Forms.TextBox textBox_artist;
        private System.Windows.Forms.Button button_guide;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel panel_Logo;
        private System.Windows.Forms.Label label_artist;
        private System.Windows.Forms.Label label_song;
        private System.Windows.Forms.TextBox textBox_song;
        private System.Windows.Forms.Label label_SongTags;
        private System.Windows.Forms.Button button_SQL;
    }
}

