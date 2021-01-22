using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETFLIX
{
    public partial class MovieForm : Form
    {
        // contains the list of movies
        private List<Movie> _movieList = new List<Movie>();
        private string _headDirectory = @".\MOVIES";
        private string _thumbnails = @".\Thumnails";
        // stores the list of panal in which category is stored
        private List<Panel> _catagoryPanels = new List<Panel>();
        // stores the category and list of movies
        private List<MovieCategory> _catogories = new List<MovieCategory>();
        // this panal constains search results
        private Panel _searchResultPanel;

        private List<String> _watchHistory = new List<string>();


        // this will load watch history
        private void LoadWatchHistory()
        {
            try
            {
                // the history is store in this file 
                String[] lines = File.ReadAllLines("./WatchHistory.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    _watchHistory.Add(lines[i]);
                    Console.WriteLine(@"retrive from watch history "+lines[i]);
                }

                // it will make new panel if the list the history exists else it will skip out
                if (_watchHistory.Count > 0)
                {
                    List<Movie> watchHistoryMovies = new List<Movie>();
                    foreach (var t in _watchHistory)
                    {
                        foreach (var movie in _movieList)
                        {
                            Console.WriteLine(t+@"--"+movie.MovieName);
                            if (t.Equals(movie.MovieName))
                            {

                                if (!watchHistoryMovies.Contains(movie))
                                {
                                    watchHistoryMovies.Add(movie);
                                }
                            }
                        }
                    }
                    // make the watch history panel
                    AddPanal(@"Watch History",watchHistoryMovies);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void AddWatchHistory(String movieName)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("./WatchHistory.txt"))
                {
                    sw.WriteLine(movieName);
                    Console.Write(@"watch history added "+movieName);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public MovieForm()
        {
            InitializeComponent();
            // "" represents all category
            categoryBox.Items.Add("");
            // intializes the category to all category
            categoryBox.SelectedIndex = 0;
            
            // enable scrolling on panel
            searchPanal.Visible = false;
            MainPanal.VerticalScroll.Enabled = true;
            MainPanal.AutoScroll = false;
            MainPanal.HorizontalScroll.Enabled = false;
            MainPanal.HorizontalScroll.Visible = false;
            MainPanal.HorizontalScroll.Maximum = 0;
            MainPanal.AutoScroll = true;
        }
        private void MovieForm_Load(object sender, EventArgs e)
        {
            // load movies into the variable
            LoadMovies();
            LoadWatchHistory();
            foreach (var movieCategory in _catogories)
            {
                try
                {
                    // make panel of the movies
                    if (movieCategory.Movies.Count > 0)
                        AddPanal(movieCategory.CategoryName, movieCategory.Movies);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void SearchPanel(string query = "")
        {
            if (query.Equals("") || query.Equals("Search"))
            {
                searchPanal.Visible = false;
            }
            else
            {
                searchPanal.Visible = true;
                // process the search query
                SearchResults(query);
            }
        }


        void SearchResults(string searchQuery = "",string category = "")
        {
            // remove old search result panel if it exists
            if(_searchResultPanel!=null)
                searchPanal.Controls.Remove(_searchResultPanel);

            // search result movies
            List<Movie> searchResults = new List<Movie>();


            // to calculate the position of the panel
            int panalNumber = 0;
            int labely = 10 + (50 * panalNumber) + (panalNumber * 200);
            int y = 40 + (50 * panalNumber) + (panalNumber * 200);
            Console.WriteLine(panalNumber + @" -- " + y + @"L:" + labely);

            // tag for panal
            Label label = new Label();
            label.Location = new Point(20, labely);
            label.AutoSize = true;
            label.Font = new Font("Calibri", 15, FontStyle.Bold);
            label.ForeColor = Color.Red;
            label.BackColor = Color.Transparent;
            label.Padding = new Padding(0);
            label.BringToFront();



            //load the search result
            for (int i = 0; i < _movieList.Count; i++)
            {
                if (!category.Equals(""))
                {
                    // for category
                    label.Text = category;
                    if (_movieList[i].Category.ToLower().Contains(category.ToLower()))
                        searchResults.Add(_movieList[i]);
                }
                else
                {
                    // for movies 
                    label.Text = @"Search Results";
                    if (_movieList[i].MovieName.ToLower().Contains(searchQuery.ToLower())) 
                        searchResults.Add(_movieList[i]);
                }
            }



            
            // create search result panel
            _searchResultPanel = new Panel();
            _searchResultPanel.Size = new Size(1500, 200);
            _searchResultPanel.BackColor = Color.Transparent;
            _searchResultPanel.Location = new Point(20, y);

            // enable horizontal scrolling
            _searchResultPanel.HorizontalScroll.Enabled = true;
            _searchResultPanel.AutoScroll = false;
            _searchResultPanel.VerticalScroll.Enabled = false;
            _searchResultPanel.VerticalScroll.Visible = false;
            _searchResultPanel.VerticalScroll.Maximum = 0;
            _searchResultPanel.AutoScroll = true;


            // add thumbnail of the movies
            for (int i = 0; i < searchResults.Count; i++)
            {
                string thumbnail = searchResults[i].Thumbnail;
                string videoURL = searchResults[i].MoviesLink;

                // position to place the thumbnail
                int x = (10 * i) + (256 * i);
                Button button = new Button();
                button.Size = new Size(256, 150);
                button.Location = new Point(x, 0);
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                if (!thumbnail.Equals(""))
                    button.BackgroundImage = Image.FromFile(thumbnail);
                button.Click += new EventHandler(playMovie_Button);
                button.Tag = videoURL;
                _searchResultPanel.Controls.Add(button);
            }

            searchPanal.Controls.Add(label);
            searchPanal.Controls.Add(_searchResultPanel);
        }

        // same as above but this will add multiple panels in the main panel
        void AddPanal(string categoryLabelText = "", List<Movie> movies = null)
        {

            int panalNumber = _catagoryPanels.Count;
            int labely = 10 + (50 * panalNumber) + (panalNumber * 200);
            int y = 40 + (50 * panalNumber) + (panalNumber * 200);
            Console.WriteLine(panalNumber + @" -- " + y + @"L:" + labely);

            Label label = new Label();
            label.Text = categoryLabelText;
            label.Location = new Point(20, labely);
            label.AutoSize = true;
            label.Font = new Font("Calibri", 15, FontStyle.Bold);
            label.ForeColor = Color.Red;
            label.BackColor = Color.Transparent;
            label.Padding = new Padding(0);
            label.BringToFront();


            Panel panel = new Panel();
            panel.Size = new Size(1500, 200);
            panel.BackColor = Color.Transparent;
            panel.Location = new Point(20, y);


            panel.HorizontalScroll.Enabled = true;
            panel.AutoScroll = false;
            panel.VerticalScroll.Enabled = false;
            panel.VerticalScroll.Visible = false;
            panel.VerticalScroll.Maximum = 0;
            panel.AutoScroll = true;


            // this will add multiple panel on cetegory
            if(movies!=null)
                for (int i = 0; i < movies.Count; i++)
                {
                    string thumbnail = movies[i].Thumbnail;
                    string videoURL = movies[i].MoviesLink;

                    int x = (10 * i) + (256 * i); 
                    Button button = new Button();
                    button.Size=new Size(256, 150);
                    button.Location = new Point(x, 0);
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    if(!thumbnail.Equals("") )
                        button.BackgroundImage = Image.FromFile(thumbnail);
                    button.Click+=new EventHandler(playMovie_Button);
                    button.Tag = videoURL;
                    panel.Controls.Add(button);
                }



            MainPanal.Controls.Add(label);
            MainPanal.Controls.Add(panel);
            _catagoryPanels.Add(panel);
        }


        // this will launch media player
        private void playMovie_Button(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            Console.WriteLine(button.Tag);
            try
            {
                String movieName = "";
                for (int i = 0; i < _movieList.Count; i++)
                {
                    if (button.Tag.ToString().Equals(_movieList[i].MoviesLink))
                    {
                        movieName = _movieList[i].MovieName;
                        AddWatchHistory(movieName);
                    }
                }

                PlayerForm player = new PlayerForm(button.Tag.ToString(),movieName);
                player.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        // this will read movies from movie folder and thumbnail folder
        private void LoadMovies()
        {
            string[] categoryDirectoriesNames = Directory.GetDirectories(_headDirectory);
            for (int i = 0; i < categoryDirectoriesNames.Length; i++)
            {
                try
                {
                    string currentDir = categoryDirectoriesNames[i];
                    string categoryName = categoryDirectoriesNames[i].Replace(_headDirectory + @"\", "");
                    Console.WriteLine(categoryName);
                    MovieCategory movieCategory = new MovieCategory(categoryName);
                    string[] currentDirFiles = Directory.GetFiles(currentDir);
                    for (int j = 0; j < currentDirFiles.Length; j++)
                    {
                        string moviesName = currentDirFiles[j].Replace(currentDir + @"\", "");
                        moviesName = moviesName.Split('.')[0];
                        if(GetThumbnailUrl(moviesName).Equals(""))
                            continue;
                        Movie movie = new Movie(GetThumbnailUrl(moviesName), currentDirFiles[j], moviesName, categoryName);
                        Console.WriteLine(movie);
                        _movieList.Add(movie);
                        movieCategory.Movies.Add(movie);
                    }
                    _catogories.Add(movieCategory);
                    categoryBox.Items.Add(movieCategory.CategoryName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
               
            }
        }


        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (searchBar.Text.Equals(""))
            {
                searchBar.Text = @"Search";
            }
            else
            {
                SearchPanel(searchBar.Text);
            }
        }


        // returns the thumbnail from the list of thumbnails in the folder
        private string GetThumbnailUrl(string movieName)
        {
            string[] thumbnailsList = Directory.GetFiles(_thumbnails);
            for (int i = 0; i < thumbnailsList.Length; i++)
            {
                if (thumbnailsList[i].Contains(movieName))
                    return thumbnailsList[i];
            }

            return "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // update the panel when category is changed
        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(categoryBox.SelectedIndex);
            
            if (categoryBox.SelectedIndex >= 0)
            {
                if (categoryBox.SelectedIndex == 0)
                {
                    searchPanal.Visible = false;
                }
                else
                {
                    searchPanal.Visible = true;
                    string category = categoryBox.SelectedItem.ToString();
                    Console.WriteLine(category);
                    SearchResults("",category);
                }
            }
        }
    }


    // class to store movie list and category
    class MovieCategory
    {
        public List<Movie> Movies = new List<Movie>();
        public string CategoryName;

        public MovieCategory(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
