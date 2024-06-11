namespace VetmanagerAPI
{
    partial class SettingsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            domainInput = new TextBox();
            loginInput = new TextBox();
            passwordInput = new TextBox();
            connectBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 50);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Домен:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 100);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 150);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Пароль:";
            // 
            // domainInput
            // 
            domainInput.Location = new Point(128, 42);
            domainInput.Name = "domainInput";
            domainInput.Size = new Size(169, 23);
            domainInput.TabIndex = 3;
            // 
            // loginInput
            // 
            loginInput.Location = new Point(128, 92);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(169, 23);
            loginInput.TabIndex = 4;
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(128, 142);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(169, 23);
            passwordInput.TabIndex = 5;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(128, 185);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(75, 23);
            connectBtn.TabIndex = 6;
            connectBtn.Text = "Связать";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += ConnectBtn_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = connectBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 236);
            Controls.Add(connectBtn);
            Controls.Add(passwordInput);
            Controls.Add(loginInput);
            Controls.Add(domainInput);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox domainInput;
        private TextBox loginInput;
        private TextBox passwordInput;
        private Button connectBtn;
    }
}