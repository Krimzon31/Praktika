namespace Employee
{
    partial class EmployeeF
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.Surname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPatronimic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textDateOfBirth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPost = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 267);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1079, 402);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // textSurname
            // 
            this.textSurname.Location = new System.Drawing.Point(64, 111);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(141, 22);
            this.textSurname.TabIndex = 1;
            // 
            // Surname
            // 
            this.Surname.AutoSize = true;
            this.Surname.Location = new System.Drawing.Point(102, 92);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(61, 16);
            this.Surname.TabIndex = 2;
            this.Surname.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(239, 111);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(145, 22);
            this.textName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Patronimic";
            // 
            // textPatronimic
            // 
            this.textPatronimic.Location = new System.Drawing.Point(425, 111);
            this.textPatronimic.Name = "textPatronimic";
            this.textPatronimic.Size = new System.Drawing.Size(158, 22);
            this.textPatronimic.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(682, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date Of Birth";
            // 
            // textDateOfBirth
            // 
            this.textDateOfBirth.Location = new System.Drawing.Point(617, 111);
            this.textDateOfBirth.Name = "textDateOfBirth";
            this.textDateOfBirth.Size = new System.Drawing.Size(212, 22);
            this.textDateOfBirth.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(876, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Post";
            // 
            // textPost
            // 
            this.textPost.Location = new System.Drawing.Point(848, 111);
            this.textPost.Name = "textPost";
            this.textPost.Size = new System.Drawing.Size(138, 22);
            this.textPost.TabIndex = 5;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(334, 185);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(132, 43);
            this.insert.TabIndex = 6;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(483, 185);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(132, 43);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(631, 185);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(132, 43);
            this.Delete.TabIndex = 13;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // EmployeeF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 681);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDateOfBirth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPatronimic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.Surname);
            this.Controls.Add(this.textSurname);
            this.Controls.Add(this.dataGridView);
            this.Name = "EmployeeF";
            this.Text = "EmployeeF";
            this.Load += new System.EventHandler(this.EmployeeF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textSurname;
        private System.Windows.Forms.Label Surname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPatronimic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDateOfBirth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPost;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
    }
}