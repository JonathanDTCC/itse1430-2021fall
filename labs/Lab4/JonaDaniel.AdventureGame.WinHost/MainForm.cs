/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;
using System.Linq;
using System.Windows.Forms;

namespace JonaDaniel.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
        }

        private Character _character;
        private Player _player;
        private GameWorld _gameWorld;
        private Character GetSelectedCharacter () => _listCharacters.SelectedItem as Character;

        #region Exit and About Buttons
        private void OnFileExit ( object sender, EventArgs e )
        {
            if (!Confirm("Do you want to quit?", "Confirm"))
                return;

            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            dlg.ShowDialog();
        }
        #endregion

        #region Character Create, Edit, Delete Buttons
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;

            UpdateUI();
        }
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var dlg = new CharacterForm();
            dlg.Character = character;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;

            UpdateUI();
        }
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{character.Name}'?", "Delete"))
                return;

            _character = null;
            UpdateUI();
        }
        #endregion
        private void UpdateUI ()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _character;

            _listCharacters.DataSource = bindingSource;
        }

        #region Popups Dialogs
        private bool Confirm ( string message, string title ) => MessageBox.Show(this, message, title,
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                                == DialogResult.Yes;

        private void DisplayError( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Game
        private void OnGameStart ( object sender, EventArgs e )
        {
            if (_listCharacters.Items.Count == 0)
            {
                DisplayError("Please Create a Character First", "Can't Start");
                return;
            }
            DisableCharacterMenu();

            StartGame();
        }

        private void StartGame ()
        {
            _gameWorld = new GameWorld();

            _player = new Player() {
                CurrentCharacter = GetSelectedCharacter(),
                CurrentPosition = GameWorld.StartArea
            };
        }

        private void DisableCharacterMenu ()
        {
            characterToolStripMenuItem.Enabled = false;
            createToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
        }

        private void EnableCharacterMenu ()
        {
            characterToolStripMenuItem.Enabled = true;
            createToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
        }
        #endregion
    }
}
