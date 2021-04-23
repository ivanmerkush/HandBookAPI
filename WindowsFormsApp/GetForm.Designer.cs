
namespace WindowsFormsApp
{
    partial class GetForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageName = new System.Windows.Forms.TabPage();
            this.usersBox = new System.Windows.Forms.ListBox();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pagePhone = new System.Windows.Forms.TabPage();
            this.userBox = new System.Windows.Forms.TextBox();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.pageName.SuspendLayout();
            this.pagePhone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageName);
            this.tabControl1.Controls.Add(this.pagePhone);
            this.tabControl1.Location = new System.Drawing.Point(24, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 403);
            this.tabControl1.TabIndex = 0;
            // 
            // pageName
            // 
            this.pageName.Controls.Add(this.usersBox);
            this.pageName.Controls.Add(this.surnameBox);
            this.pageName.Controls.Add(this.nameBox);
            this.pageName.Controls.Add(this.label2);
            this.pageName.Controls.Add(this.label1);
            this.pageName.Location = new System.Drawing.Point(4, 24);
            this.pageName.Name = "pageName";
            this.pageName.Padding = new System.Windows.Forms.Padding(3);
            this.pageName.Size = new System.Drawing.Size(428, 375);
            this.pageName.TabIndex = 0;
            this.pageName.Text = "Name and Surname";
            this.pageName.UseVisualStyleBackColor = true;
            // 
            // usersBox
            // 
            this.usersBox.FormattingEnabled = true;
            this.usersBox.ItemHeight = 15;
            this.usersBox.Location = new System.Drawing.Point(29, 129);
            this.usersBox.Name = "usersBox";
            this.usersBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.usersBox.Size = new System.Drawing.Size(380, 214);
            this.usersBox.TabIndex = 4;
            // 
            // surnameBox
            // 
            this.surnameBox.Location = new System.Drawing.Point(222, 64);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(188, 23);
            this.surnameBox.TabIndex = 3;
            this.surnameBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.surnameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBox_KeyPress);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 64);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(190, 23);
            this.nameBox.TabIndex = 2;
            this.nameBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.nameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // pagePhone
            // 
            this.pagePhone.Controls.Add(this.userBox);
            this.pagePhone.Controls.Add(this.phoneBox);
            this.pagePhone.Controls.Add(this.label3);
            this.pagePhone.Location = new System.Drawing.Point(4, 24);
            this.pagePhone.Name = "pagePhone";
            this.pagePhone.Padding = new System.Windows.Forms.Padding(3);
            this.pagePhone.Size = new System.Drawing.Size(428, 375);
            this.pagePhone.TabIndex = 1;
            this.pagePhone.Text = "Phone";
            this.pagePhone.UseVisualStyleBackColor = true;
            // 
            // userBox
            // 
            this.userBox.Enabled = false;
            this.userBox.Location = new System.Drawing.Point(34, 164);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(372, 23);
            this.userBox.TabIndex = 2;
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(115, 68);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(215, 23);
            this.phoneBox.TabIndex = 1;
            this.phoneBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.phoneBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // GetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "GetForm";
            this.Text = "GetForm";
            this.tabControl1.ResumeLayout(false);
            this.pageName.ResumeLayout(false);
            this.pageName.PerformLayout();
            this.pagePhone.ResumeLayout(false);
            this.pagePhone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageName;
        private System.Windows.Forms.TabPage pagePhone;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox usersBox;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}