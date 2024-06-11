namespace VetmanagerAPI
{
    partial class PetForm
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
            petNameLabel = new Label();
            petNameTextBox = new TextBox();
            petTypeLabel = new Label();
            petTypeComboBox = new ComboBox();
            petBreedLabel = new Label();
            petBreedComboBox = new ComboBox();
            petGenderLabel = new Label();
            petGenderComboBox = new ComboBox();
            petBirthLabel = new Label();
            petDateTimePicker = new DateTimePicker();
            petSaveButton = new Button();
            SuspendLayout();
            // 
            // petNameLabel
            // 
            petNameLabel.AutoSize = true;
            petNameLabel.Location = new Point(12, 15);
            petNameLabel.Name = "petNameLabel";
            petNameLabel.Size = new Size(58, 15);
            petNameLabel.TabIndex = 0;
            petNameLabel.Text = "Кличка: *";
            // 
            // petNameTextBox
            // 
            petNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            petNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            petNameTextBox.Location = new Point(116, 12);
            petNameTextBox.Name = "petNameTextBox";
            petNameTextBox.Size = new Size(176, 23);
            petNameTextBox.TabIndex = 1;
            // 
            // petTypeLabel
            // 
            petTypeLabel.AutoSize = true;
            petTypeLabel.Location = new Point(12, 54);
            petTypeLabel.Name = "petTypeLabel";
            petTypeLabel.Size = new Size(30, 15);
            petTypeLabel.TabIndex = 2;
            petTypeLabel.Text = "Вид:";
            // 
            // petTypeComboBox
            // 
            petTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            petTypeComboBox.DisplayMember = "title";
            petTypeComboBox.FormattingEnabled = true;
            petTypeComboBox.Location = new Point(116, 51);
            petTypeComboBox.Name = "petTypeComboBox";
            petTypeComboBox.Size = new Size(176, 23);
            petTypeComboBox.TabIndex = 3;
            petTypeComboBox.ValueMember = "id";
            petTypeComboBox.SelectedIndexChanged += PetType_SelectedIndexChanged;
            // 
            // petBreedLabel
            // 
            petBreedLabel.AutoSize = true;
            petBreedLabel.Location = new Point(12, 94);
            petBreedLabel.Name = "petBreedLabel";
            petBreedLabel.Size = new Size(52, 15);
            petBreedLabel.TabIndex = 4;
            petBreedLabel.Text = "Порода:";
            // 
            // petBreedComboBox
            // 
            petBreedComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            petBreedComboBox.DisplayMember = "title";
            petBreedComboBox.FormattingEnabled = true;
            petBreedComboBox.Location = new Point(116, 91);
            petBreedComboBox.Name = "petBreedComboBox";
            petBreedComboBox.Size = new Size(176, 23);
            petBreedComboBox.TabIndex = 5;
            petBreedComboBox.ValueMember = "id";
            // 
            // petGenderLabel
            // 
            petGenderLabel.AutoSize = true;
            petGenderLabel.Location = new Point(12, 136);
            petGenderLabel.Name = "petGenderLabel";
            petGenderLabel.Size = new Size(33, 15);
            petGenderLabel.TabIndex = 6;
            petGenderLabel.Text = "Пол:";
            // 
            // petGenderComboBox
            // 
            petGenderComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            petGenderComboBox.FormattingEnabled = true;
            petGenderComboBox.Items.AddRange(new object[] { "male", "female", "castrated", "sterilized" });
            petGenderComboBox.Location = new Point(116, 133);
            petGenderComboBox.Name = "petGenderComboBox";
            petGenderComboBox.Size = new Size(176, 23);
            petGenderComboBox.TabIndex = 7;
            // 
            // petBirthLabel
            // 
            petBirthLabel.AutoSize = true;
            petBirthLabel.Location = new Point(12, 184);
            petBirthLabel.Name = "petBirthLabel";
            petBirthLabel.Size = new Size(93, 15);
            petBirthLabel.TabIndex = 8;
            petBirthLabel.Text = "Дата рождения:";
            // 
            // petDateTimePicker
            // 
            petDateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            petDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            petDateTimePicker.Format = DateTimePickerFormat.Custom;
            petDateTimePicker.Location = new Point(116, 178);
            petDateTimePicker.Name = "petDateTimePicker";
            petDateTimePicker.Size = new Size(176, 23);
            petDateTimePicker.TabIndex = 9;
            // 
            // petSaveButton
            // 
            petSaveButton.Anchor = AnchorStyles.Bottom;
            petSaveButton.Location = new Point(116, 235);
            petSaveButton.Name = "petSaveButton";
            petSaveButton.Size = new Size(75, 23);
            petSaveButton.TabIndex = 10;
            petSaveButton.Text = "Сохранить";
            petSaveButton.UseVisualStyleBackColor = true;
            petSaveButton.Click += PetSaveButton_Click;
            // 
            // PetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 291);
            Controls.Add(petSaveButton);
            Controls.Add(petDateTimePicker);
            Controls.Add(petBirthLabel);
            Controls.Add(petGenderComboBox);
            Controls.Add(petGenderLabel);
            Controls.Add(petBreedComboBox);
            Controls.Add(petBreedLabel);
            Controls.Add(petTypeComboBox);
            Controls.Add(petTypeLabel);
            Controls.Add(petNameTextBox);
            Controls.Add(petNameLabel);
            Name = "PetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PetForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label petNameLabel;
        private TextBox petNameTextBox;
        private Label petTypeLabel;
        private ComboBox petTypeComboBox;
        private Label petBreedLabel;
        private ComboBox petBreedComboBox;
        private Label petGenderLabel;
        private ComboBox petGenderComboBox;
        private Label petBirthLabel;
        private DateTimePicker petDateTimePicker;
        private Button petSaveButton;
    }
}