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
        private void OnFileExit ( object sender, EventArgs e )
        {
            //TODO: Confirm
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            dlg.ShowDialog();
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;

            UpdateUI();
        }

        private void UpdateUI ()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _character;

            _listCharacters.DataSource = bindingSource;
        }
    }
}
