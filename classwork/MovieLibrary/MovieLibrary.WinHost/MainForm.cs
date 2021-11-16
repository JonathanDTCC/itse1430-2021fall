using System;
using System.Linq;
using System.Windows.Forms;

using MovieLibrary.Memory;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            //Additional init here
            //Runs at design time as well - be careful
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //Confirm exit?
            if (!Confirm("Do you want to quit?", "Confirm"))
                return;

            Close();
        }

        private bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title,
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            //Blocks until child form is closed
            dlg.ShowDialog();

            //Show displays modeless, not blocking
            //dlg.Show();
            //MessageBox.Show("After Show");
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            do
            {
                //ShowDialog -> DialogResult
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _movies.Add(dlg.Movie);
                    UpdateUI();
                    return;
                } catch (ArgumentException ex)
                {
                    DisplayError(ex.Message, "Progammer Error");
                } catch (InvalidOperationException ex)
                {
                    DisplayError(ex.Message, "Not Now");
                } catch (NotSupportedException ex)
                {
                    DisplayError("Not supported", "error");
                    //Do some logging
                    throw;
                } catch (System.IO.IOException ex) 
                {
                    throw new Exception("IO failed", ex);
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Failed");
                };
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                //ShowDialog -> DialogResult
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    _movies.Update(movie.Id, dlg.Movie);
                    UpdateUI();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed");
                }
            } while (true);
        }

        private Movie GetSelectedMovie ()
        {
            return _listMovies.SelectedItem as Movie;
        }


        private IMovieDatabase _movies = new MemoryMovieDatabase();

        private void UpdateUI ( bool isFirstRun = false )
        {
            //IEnumerable<TextBox> onlyTextBoxes = Controls.OfType<TextBox>();

            //Update movie list
            var movies = _movies.GetAll();
            if (isFirstRun && !movies.Any())
            {
                if (Confirm("Do you want to seed the database?", "Seed"))
                {
                    _movies.Seed();
                    //SeedDatabase.Seed(_movies);
                    movies = _movies.GetAll();
                };
            };

            //LINQ extension
            //movies = movies.OrderBy(x => x.Title)
            //                .ThenBy(x => x.ReleaseYear);

            //LINQ syntax
            movies = from x in movies
                     orderby x.Title, x.ReleaseYear
                     select x;

            var bindingSource = new BindingSource();
            //bindingSource.DataSource = movies
            //                            .OrderBy(x => x.Title)
            //                            .ThenBy(x => x.ReleaseYear)
            //                            .ToArray();
            bindingSource.DataSource = movies.ToArray();

            //bind the movies to the listbox
            _listMovies.DataSource = bindingSource;
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //_movies.IsOnlyAvailableInMemoryMovieDatabase();
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirmation
            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            try
            {
            _movies.Delete(movie.Id);
            UpdateUI();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            }

        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
