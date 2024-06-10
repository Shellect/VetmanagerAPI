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
            button1 = new Button();
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
            // button1
            // 
            button1.Location = new Point(675, 30);
            button1.Name = "button1";
            button1.Size = new Size(100, 25);
            button1.TabIndex = 0;
            button1.Text = "Настройки API";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
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
            DeleteBtn.Location = new Point(665, 84);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(110, 23);
            DeleteBtn.TabIndex = 4;
            DeleteBtn.Text = "Удалить";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // EditBtn
            // 
            EditBtn.Location = new Point(549, 84);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(110, 23);
            EditBtn.TabIndex = 5;
            EditBtn.Text = "Редактировать:";
            EditBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(433, 84);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(110, 23);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Добавить";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // petsGridView
            // 
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
            Controls.Add(button1);
            Name = "MainForm";
            Text = "VetmanagerAPI";
            ((System.ComponentModel.ISupportInitialize)petsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button button1;
        private ComboBox clientsComboBox;
        private Label label1;
        private Label label2;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button AddBtn;
        private DataGridView petsGridView;
    }
}
