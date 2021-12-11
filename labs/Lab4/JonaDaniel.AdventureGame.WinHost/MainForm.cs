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
        public MainForm ()
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

        private void DisplayError ( string message, string title )
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
                CurrentPosition = _gameWorld.StartingArea,
                Inventory = new Inventory(),
            };

            _groupArea.Enabled = true;
            _groupMove.Enabled = true;

            startToolStripMenuItem.Enabled = false;
            endToolStripMenuItem.Enabled = true;
            UpdateArea();
        }
        private void OnGameEnd ( object sender, EventArgs e )
        {
            EnableCharacterMenu();

            EndGame();
        }

        private void EndGame ()
        {
            _txtAreaName.Text = "";
            _txtAreaDescription.Text = "";

            _gameWorld = null;

            _player = null;

            _groupArea.Enabled = false;
            _groupMove.Enabled = false;

            startToolStripMenuItem.Enabled = true;
            endToolStripMenuItem.Enabled = false;
        }



        private void UpdateArea ()
        {
            _txtAreaName.Text = _player.CurrentPosition.Name;
            _txtAreaDescription.Text = _player.CurrentPosition.Description;

            _btnNorth.Enabled = _player.CurrentPosition.AccessibleAreas[0] != 0;
            _btnEast.Enabled = _player.CurrentPosition.AccessibleAreas[1] != 0;
            _btnSouth.Enabled = _player.CurrentPosition.AccessibleAreas[2] != 0;
            _btnWest.Enabled = _player.CurrentPosition.AccessibleAreas[3] != 0;
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

        #region Move
        private void OnMoveNorth ( object sender, EventArgs e )
        {
            _player.CurrentPosition = _gameWorld.FindArea(_player.CurrentPosition.AccessibleAreas[0]);
            UpdateArea();
        }

        private void OnMoveEast ( object sender, EventArgs e )
        {
            _player.CurrentPosition = _gameWorld.FindArea(_player.CurrentPosition.AccessibleAreas[1]);
            UpdateArea();
        }

        private void OnMoveSouth ( object sender, EventArgs e )
        {
            _player.CurrentPosition = _gameWorld.FindArea(_player.CurrentPosition.AccessibleAreas[2]);
            UpdateArea();
        }

        private void OnMoveWest ( object sender, EventArgs e )
        {
            _player.CurrentPosition = _gameWorld.FindArea(_player.CurrentPosition.AccessibleAreas[3]);
            UpdateArea();
        }
        #endregion
    }
}
