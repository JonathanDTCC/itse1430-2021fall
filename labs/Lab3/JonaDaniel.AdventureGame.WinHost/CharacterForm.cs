/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;
using System.Windows.Forms;

namespace JonaDaniel.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        #region Loading
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadCharacter(Character);

            //TODO: Validate
        }

        /// <summary>Loads character information into form.</summary>
        /// <param name="character"></param>
        private void LoadCharacter ( Character character )
        {
            _txtName.Text = character.Name;
            _cbProfession.Text = character.Profession;
            _cbRace.Text = character.Race;
            _txtBiography.Text = character.Biography;

            _txtStrength.Text = character.Strength.ToString();
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Charisma.ToString();
        }

        #endregion

        /// <summary>Called when save button is pressed. Validates character information. If valid sets character for use on main form and closes form.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSave ( object sender, EventArgs e )
        {
            //TODO: Add Form Validation

            //Build up a Character
            var character = new Character();
            character.Name = _txtName.Text;
            character.Profession = _cbProfession.Text;
            character.Race = _cbRace.Text;
            character.Biography = _txtBiography.Text;

            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);

            var error = character.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            };

            Character = character;
        }

        #region Validation and Error Display
        /// <summary>Displays an error with the given message and title</summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Converts text from text box control into an Integer, returns -1 if failed to parse</summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int GetInt32 ( Control /*TextBox*/ control )
        {
            var text = control.Text;
            return Int32.TryParse(text, out var result) ? result : -1;
        }
        #endregion
    }
}
