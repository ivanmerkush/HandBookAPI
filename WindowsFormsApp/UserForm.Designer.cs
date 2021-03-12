
namespace WindowsFormsApp
{
    partial class UserForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.getButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.dbMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Notifier = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userMenu,
            this.dbMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(553, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userMenu
            // 
            this.userMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getButton,
            this.addButton,
            this.editButton,
            this.deleteButton});
            this.userMenu.Name = "userMenu";
            this.userMenu.Size = new System.Drawing.Size(47, 20);
            this.userMenu.Text = "Users";
            // 
            // getButton
            // 
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(180, 22);
            this.getButton.Text = "Get";
            this.getButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // addButton
            // 
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(180, 22);
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(180, 22);
            this.editButton.Text = "Edit";
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(180, 22);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dbMenu
            // 
            this.dbMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadButton,
            this.saveButton});
            this.dbMenu.Name = "dbMenu";
            this.dbMenu.Size = new System.Drawing.Size(67, 20);
            this.dbMenu.Text = "Database";
            // 
            // loadButton
            // 
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(157, 22);
            this.loadButton.Text = "Load users";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(157, 22);
            this.saveButton.Text = "Save current list";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Notifier);
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 425);
            this.panel1.TabIndex = 1;
            // 
            // userList
            // 
            this.userList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(0, 28);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(282, 394);
            this.userList.TabIndex = 5;
            this.userList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Users";
            // 
            // Notifier
            // 
            this.Notifier.AutoSize = true;
            this.Notifier.Location = new System.Drawing.Point(406, 8);
            this.Notifier.Name = "Notifier";
            this.Notifier.Size = new System.Drawing.Size(40, 13);
            this.Notifier.TabIndex = 2;
            this.Notifier.Text = "Notifier";
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(282, 28);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(271, 394);
            this.textBox.TabIndex = 1;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.Text = "Handbook";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userMenu;
        private System.Windows.Forms.ToolStripMenuItem getButton;
        private System.Windows.Forms.ToolStripMenuItem addButton;
        private System.Windows.Forms.ToolStripMenuItem editButton;
        private System.Windows.Forms.ToolStripMenuItem deleteButton;
        private System.Windows.Forms.ToolStripMenuItem dbMenu;
        private System.Windows.Forms.ToolStripMenuItem loadButton;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Notifier;
        internal System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox userList;
    }
}

