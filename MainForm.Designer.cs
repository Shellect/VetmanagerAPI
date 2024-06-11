namespace VetmanagerAPI
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
            APIButton = new Button();
            clientsComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            DeleteBtn = new Button();
            EditBtn = new Button();
            AddBtn = new Button();
            petsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)petsGridView).BeginInit();
            SuspendLayout();
            // 
            // APIButton
            // 
            APIButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            APIButton.Location = new Point(675, 30);
            APIButton.Name = "APIButton";
            APIButton.Size = new Size(100, 25);
            APIButton.TabIndex = 0;
            APIButton.Text = "Настройки API";
            APIButton.UseVisualStyleBackColor = true;
            APIButton.Click += APIButton_Click;
            // 
            // clientsComboBox
            // 
            clientsComboBox.FormattingEnabled = true;
            clientsComboBox.Location = new Point(90, 30);
            clientsComboBox.Name = "clientsComboBox";
            clientsComboBox.Size = new Size(334, 23);
            clientsComboBox.TabIndex = 1;
            clientsComboBox.SelectedIndexChanged += Clients_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "Клиент:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 88);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 3;
            label2.Text = "Питомцы клиента:";
            // 
            // DeleteBtn
            // 
            DeleteBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteBtn.Enabled = false;
            DeleteBtn.Location = new Point(665, 84);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(110, 23);
            DeleteBtn.TabIndex = 4;
            DeleteBtn.Text = "Удалить";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // EditBtn
            // 
            EditBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditBtn.Enabled = false;
            EditBtn.Location = new Point(549, 84);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(110, 23);
            EditBtn.TabIndex = 5;
            EditBtn.Text = "Редактировать:";
            EditBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            AddBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddBtn.Enabled = false;
            AddBtn.Location = new Point(433, 84);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(110, 23);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Добавить";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // petsGridView
            // 
            petsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            petsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            petsGridView.Location = new Point(25, 140);
            petsGridView.Name = "petsGridView";
            petsGridView.Size = new Size(750, 298);
            petsGridView.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(petsGridView);
            Controls.Add(AddBtn);
            Controls.Add(EditBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientsComboBox);
            Controls.Add(APIButton);
            Name = "MainForm";
            Text = "VetmanagerAPI";
            ((System.ComponentModel.ISupportInitialize)petsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button APIButton;
        private ComboBox clientsComboBox;
        private Label label1;
        private Label label2;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button AddBtn;
        private DataGridView petsGridView;
    }
}
