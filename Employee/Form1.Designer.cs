namespace Employee
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Employee = new System.Windows.Forms.Button();
            this.Skill = new System.Windows.Forms.Button();
            this.Task = new System.Windows.Forms.Button();
            this.CurrentLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Employee
            // 
            this.Employee.Location = new System.Drawing.Point(395, 209);
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(145, 59);
            this.Employee.TabIndex = 0;
            this.Employee.Text = "Сотрудники";
            this.Employee.UseVisualStyleBackColor = true;
            this.Employee.Click += new System.EventHandler(this.Employee_Click);
            // 
            // Skill
            // 
            this.Skill.Location = new System.Drawing.Point(395, 274);
            this.Skill.Name = "Skill";
            this.Skill.Size = new System.Drawing.Size(145, 59);
            this.Skill.TabIndex = 1;
            this.Skill.Text = "Навыки";
            this.Skill.UseVisualStyleBackColor = true;
            this.Skill.Click += new System.EventHandler(this.Skill_Click);
            // 
            // Task
            // 
            this.Task.Location = new System.Drawing.Point(395, 339);
            this.Task.Name = "Task";
            this.Task.Size = new System.Drawing.Size(145, 59);
            this.Task.TabIndex = 2;
            this.Task.Text = "Задачи";
            this.Task.UseVisualStyleBackColor = true;
            this.Task.Click += new System.EventHandler(this.Task_Click);
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.Location = new System.Drawing.Point(395, 404);
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.Size = new System.Drawing.Size(145, 59);
            this.CurrentLevel.TabIndex = 3;
            this.CurrentLevel.Text = "Текущий уровень";
            this.CurrentLevel.UseVisualStyleBackColor = true;
            this.CurrentLevel.Click += new System.EventHandler(this.CurrentLevel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 687);
            this.Controls.Add(this.CurrentLevel);
            this.Controls.Add(this.Task);
            this.Controls.Add(this.Skill);
            this.Controls.Add(this.Employee);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Employee;
        private System.Windows.Forms.Button Skill;
        private System.Windows.Forms.Button Task;
        private System.Windows.Forms.Button CurrentLevel;
    }
}

