
namespace JonaDaniel.AdventureGame.WinHost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._listCharacters = new System.Windows.Forms.ListBox();
            this._groupArea = new System.Windows.Forms.GroupBox();
            this._groupInventory = new System.Windows.Forms.GroupBox();
            this._listInventory = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtAreaDescription = new System.Windows.Forms.TextBox();
            this._txtAreaName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._groupMove = new System.Windows.Forms.GroupBox();
            this._groupInteract = new System.Windows.Forms.GroupBox();
            this._btnInvClose = new System.Windows.Forms.Button();
            this._btnInvOpen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._btnPickup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._btnNorth = new System.Windows.Forms.Button();
            this._btnEast = new System.Windows.Forms.Button();
            this._btnSouth = new System.Windows.Forms.Button();
            this._btnWest = new System.Windows.Forms.Button();
            this._lblTotalWeight = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._groupArea.SuspendLayout();
            this._groupInventory.SuspendLayout();
            this._groupMove.SuspendLayout();
            this._groupInteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.characterToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnFileExit);
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.characterToolStripMenuItem.Text = "&Character";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.createToolStripMenuItem.Text = "&New";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.OnCharacterNew);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.OnCharacterEdit);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.OnCharacterDelete);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.endToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.OnGameStart);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Enabled = false;
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.endToolStripMenuItem.Text = "End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.OnGameEnd);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this._listCharacters, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._groupArea, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._groupMove, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 537);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _listCharacters
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._listCharacters, 2);
            this._listCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listCharacters.FormattingEnabled = true;
            this._listCharacters.ItemHeight = 15;
            this._listCharacters.Location = new System.Drawing.Point(3, 361);
            this._listCharacters.Name = "_listCharacters";
            this._listCharacters.Size = new System.Drawing.Size(778, 173);
            this._listCharacters.TabIndex = 0;
            // 
            // _groupArea
            // 
            this._groupArea.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._groupArea.Controls.Add(this._groupInventory);
            this._groupArea.Controls.Add(this._txtAreaDescription);
            this._groupArea.Controls.Add(this._txtAreaName);
            this._groupArea.Controls.Add(this.label3);
            this._groupArea.Controls.Add(this.label2);
            this._groupArea.Controls.Add(this.label1);
            this._groupArea.Enabled = false;
            this._groupArea.Location = new System.Drawing.Point(3, 29);
            this._groupArea.Name = "_groupArea";
            this._groupArea.Size = new System.Drawing.Size(307, 300);
            this._groupArea.TabIndex = 1;
            this._groupArea.TabStop = false;
            // 
            // _groupInventory
            // 
            this._groupInventory.Controls.Add(this._lblTotalWeight);
            this._groupInventory.Controls.Add(this._listInventory);
            this._groupInventory.Controls.Add(this.label6);
            this._groupInventory.Location = new System.Drawing.Point(0, 151);
            this._groupInventory.Name = "_groupInventory";
            this._groupInventory.Size = new System.Drawing.Size(307, 169);
            this._groupInventory.TabIndex = 5;
            this._groupInventory.TabStop = false;
            this._groupInventory.Visible = false;
            // 
            // _listInventory
            // 
            this._listInventory.FormattingEnabled = true;
            this._listInventory.ItemHeight = 15;
            this._listInventory.Location = new System.Drawing.Point(7, 54);
            this._listInventory.Name = "_listInventory";
            this._listInventory.Size = new System.Drawing.Size(294, 94);
            this._listInventory.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(9, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "Inventory";
            // 
            // _txtAreaDescription
            // 
            this._txtAreaDescription.Location = new System.Drawing.Point(83, 94);
            this._txtAreaDescription.Multiline = true;
            this._txtAreaDescription.Name = "_txtAreaDescription";
            this._txtAreaDescription.ReadOnly = true;
            this._txtAreaDescription.Size = new System.Drawing.Size(181, 51);
            this._txtAreaDescription.TabIndex = 4;
            // 
            // _txtAreaName
            // 
            this._txtAreaName.Location = new System.Drawing.Point(83, 64);
            this._txtAreaName.Name = "_txtAreaName";
            this._txtAreaName.ReadOnly = true;
            this._txtAreaName.Size = new System.Drawing.Size(135, 23);
            this._txtAreaName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(71, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area View";
            // 
            // _groupMove
            // 
            this._groupMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._groupMove.Controls.Add(this._groupInteract);
            this._groupMove.Controls.Add(this.label4);
            this._groupMove.Controls.Add(this._btnNorth);
            this._groupMove.Controls.Add(this._btnEast);
            this._groupMove.Controls.Add(this._btnSouth);
            this._groupMove.Controls.Add(this._btnWest);
            this._groupMove.Enabled = false;
            this._groupMove.Location = new System.Drawing.Point(316, 182);
            this._groupMove.Name = "_groupMove";
            this._groupMove.Size = new System.Drawing.Size(465, 173);
            this._groupMove.TabIndex = 2;
            this._groupMove.TabStop = false;
            // 
            // _groupInteract
            // 
            this._groupInteract.Controls.Add(this._btnInvClose);
            this._groupInteract.Controls.Add(this._btnInvOpen);
            this._groupInteract.Controls.Add(this.label7);
            this._groupInteract.Controls.Add(this._btnPickup);
            this._groupInteract.Controls.Add(this.label5);
            this._groupInteract.Location = new System.Drawing.Point(288, 0);
            this._groupInteract.Name = "_groupInteract";
            this._groupInteract.Size = new System.Drawing.Size(177, 173);
            this._groupInteract.TabIndex = 5;
            this._groupInteract.TabStop = false;
            // 
            // _btnInvClose
            // 
            this._btnInvClose.Enabled = false;
            this._btnInvClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnInvClose.Location = new System.Drawing.Point(71, 128);
            this._btnInvClose.Name = "_btnInvClose";
            this._btnInvClose.Size = new System.Drawing.Size(59, 39);
            this._btnInvClose.TabIndex = 9;
            this._btnInvClose.Text = "Close";
            this._btnInvClose.UseVisualStyleBackColor = true;
            this._btnInvClose.Click += new System.EventHandler(this.OnInvClose);
            // 
            // _btnInvOpen
            // 
            this._btnInvOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnInvOpen.Location = new System.Drawing.Point(6, 128);
            this._btnInvOpen.Name = "_btnInvOpen";
            this._btnInvOpen.Size = new System.Drawing.Size(59, 39);
            this._btnInvOpen.TabIndex = 8;
            this._btnInvOpen.Text = "Open";
            this._btnInvOpen.UseVisualStyleBackColor = true;
            this._btnInvOpen.Click += new System.EventHandler(this.OnInvOpen);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Inventory";
            // 
            // _btnPickup
            // 
            this._btnPickup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnPickup.Location = new System.Drawing.Point(6, 53);
            this._btnPickup.Name = "_btnPickup";
            this._btnPickup.Size = new System.Drawing.Size(86, 44);
            this._btnPickup.TabIndex = 6;
            this._btnPickup.Text = "Pickup";
            this._btnPickup.UseVisualStyleBackColor = true;
            this._btnPickup.Click += new System.EventHandler(this.OnPickup);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Interact";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Move";
            // 
            // _btnNorth
            // 
            this._btnNorth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnNorth.Location = new System.Drawing.Point(104, 53);
            this._btnNorth.Name = "_btnNorth";
            this._btnNorth.Size = new System.Drawing.Size(86, 44);
            this._btnNorth.TabIndex = 3;
            this._btnNorth.Text = "North";
            this._btnNorth.UseVisualStyleBackColor = true;
            this._btnNorth.Click += new System.EventHandler(this.OnMoveNorth);
            // 
            // _btnEast
            // 
            this._btnEast.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnEast.Location = new System.Drawing.Point(196, 103);
            this._btnEast.Name = "_btnEast";
            this._btnEast.Size = new System.Drawing.Size(86, 44);
            this._btnEast.TabIndex = 2;
            this._btnEast.Text = "East";
            this._btnEast.UseVisualStyleBackColor = true;
            this._btnEast.Click += new System.EventHandler(this.OnMoveEast);
            // 
            // _btnSouth
            // 
            this._btnSouth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnSouth.Location = new System.Drawing.Point(104, 103);
            this._btnSouth.Name = "_btnSouth";
            this._btnSouth.Size = new System.Drawing.Size(86, 44);
            this._btnSouth.TabIndex = 1;
            this._btnSouth.Text = "South";
            this._btnSouth.UseVisualStyleBackColor = true;
            this._btnSouth.Click += new System.EventHandler(this.OnMoveSouth);
            // 
            // _btnWest
            // 
            this._btnWest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnWest.Location = new System.Drawing.Point(12, 103);
            this._btnWest.Name = "_btnWest";
            this._btnWest.Size = new System.Drawing.Size(86, 44);
            this._btnWest.TabIndex = 0;
            this._btnWest.Text = "West";
            this._btnWest.UseVisualStyleBackColor = true;
            this._btnWest.Click += new System.EventHandler(this.OnMoveWest);
            // 
            // _lblTotalWeight
            // 
            this._lblTotalWeight.AutoSize = true;
            this._lblTotalWeight.Location = new System.Drawing.Point(181, 30);
            this._lblTotalWeight.Name = "_lblTotalWeight";
            this._lblTotalWeight.Size = new System.Drawing.Size(65, 15);
            this._lblTotalWeight.TabIndex = 2;
            this._lblTotalWeight.Text = "0.0 Pounds";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.Text = "Jonathan Adventure";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this._groupArea.ResumeLayout(false);
            this._groupArea.PerformLayout();
            this._groupInventory.ResumeLayout(false);
            this._groupInventory.PerformLayout();
            this._groupMove.ResumeLayout(false);
            this._groupMove.PerformLayout();
            this._groupInteract.ResumeLayout(false);
            this._groupInteract.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox _listCharacters;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.GroupBox _groupArea;
        private System.Windows.Forms.TextBox _txtAreaDescription;
        private System.Windows.Forms.TextBox _txtAreaName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox _groupMove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnNorth;
        private System.Windows.Forms.Button _btnEast;
        private System.Windows.Forms.Button _btnSouth;
        private System.Windows.Forms.Button _btnWest;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.GroupBox _groupInteract;
        private System.Windows.Forms.Button _btnPickup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox _groupInventory;
        private System.Windows.Forms.ListBox _listInventory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _btnInvClose;
        private System.Windows.Forms.Button _btnInvOpen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _lblTotalWeight;
    }
}

