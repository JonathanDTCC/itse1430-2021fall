// ITSE 1430
// Movie Library

using System;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        ////Called when the form asked to close
        //protected override void OnFormClosing ( FormClosingEventArgs e )
        //{
        //    base.OnFormClosing(e);

        //    //Confirm to close if title is set
        //    if (_txtTitle.Text.Length > 0)
        //    {
        //        if (!Confirm("Are you sure you want to close without saving?", "Close"))
        //        e.Cancel = true;
        //    }
        //}
        //private bool Confirm ( string message, string title )
        //{
        //    return MessageBox.Show(this, message, title,
        //                           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        //                == DialogResult.Yes;
        //}

        protected override void OnLoad ( EventArgs e )
        {
            //Always call base version first
            base.OnLoad(e);

            //Load UI, if necessary
            if (Movie != null)
                LoadMovie(Movie);

            //Validate so user can see what is required
            ValidateChildren();
        }

        private void LoadMovie ( Movie movie )
        {
            _txtTitle.Text = movie.Title;
            _txtDescription.Text = movie.Description;
            _cbRating.Text = movie.Rating;
            _txtRunLength.Text = movie.RunLength.ToString();
            _txtReleaseYear.Text = movie.ReleaseYear.ToString();
            _chkIsClassic.Checked = movie.IsClassic;
        }

        //Called when Save clicked
        private void OnSave ( object sender, EventArgs e )
        {
            //Validate children
            if(!ValidateChildren())
                {
                DialogResult = DialogResult.None;
                return;
            };

            //Build up a Movie
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            movie.IsClassic = _chkIsClassic.Checked;

            //Validate
            if (!ObjectValidator.TryValidate(movie, out var error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            };

            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //{
            //    DisplayError(error, "Error");
            //    DialogResult = DialogResult.None;
            //    return;
            //};

            Movie = movie;

            //TODO: Return movie

            //Close the form
            //Close();
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetInt32 ( Control /*TextBox*/ control )
        {
            var text = control.Text;
            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void _txtTitle_KeyUp ( object sender, KeyEventArgs e )
        {
            var target = sender as TextBox;

            System.Diagnostics.Debug.WriteLine($"KeyUp: Text = {target.Name} Key = {e.KeyCode}");
        }

        private void OnValidatingTitle ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;
            //title is required
            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //not valid
            _errors.SetError(control, "Title is required");
            e.Cancel = true;
        }

        private void OnValidatingRating ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;
            //rating is required
            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //not valid
            _errors.SetError(control, "Rating is required");
            e.Cancel = true;
        }

        private void OnValidatingRunLength ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;
            //Run length >= 0
            var value = GetInt32(control);
            if (value >= 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //not valid
            _errors.SetError(control, "Run Length must be >= 0");
            e.Cancel = true;
        }

        private void OnValidatingReleaseYear ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;
            //Release Year >= MinReleaseYear
            var value = GetInt32(control);
            if (value >= Movie.MinimumReleaseYear)
            {
                _errors.SetError(control, "");
                return;
            }

            //not valid
            _errors.SetError(control, $"Release Year must be >= {Movie.MinimumReleaseYear}");
            e.Cancel = true;
        }
    }
}
