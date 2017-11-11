namespace Paypal_Recurring_Payment
{
    partial class configForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configForm));
            this.label1 = new System.Windows.Forms.Label();
            this.paypalPwd = new System.Windows.Forms.TextBox();
            this.paymntSourceGrpBox = new System.Windows.Forms.GroupBox();
            this.loadText = new System.Windows.Forms.Label();
            this.GetPaySourceBT = new System.Windows.Forms.Button();
            this.savePref = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paypalUsername = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.amountTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendUser = new System.Windows.Forms.TextBox();
            this.schedGrpBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dayMonthTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.taskNameTxtBox = new System.Windows.Forms.TextBox();
            this.jobSchedBt = new System.Windows.Forms.Button();
            this.paymntSourceGrpBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.schedGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PayPal Password: ";
            // 
            // paypalPwd
            // 
            this.paypalPwd.Location = new System.Drawing.Point(175, 59);
            this.paypalPwd.Name = "paypalPwd";
            this.paypalPwd.PasswordChar = '*';
            this.paypalPwd.Size = new System.Drawing.Size(191, 20);
            this.paypalPwd.TabIndex = 2;
            // 
            // paymntSourceGrpBox
            // 
            this.paymntSourceGrpBox.Controls.Add(this.loadText);
            this.paymntSourceGrpBox.Controls.Add(this.GetPaySourceBT);
            this.paymntSourceGrpBox.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymntSourceGrpBox.Location = new System.Drawing.Point(7, 246);
            this.paymntSourceGrpBox.Name = "paymntSourceGrpBox";
            this.paymntSourceGrpBox.Size = new System.Drawing.Size(495, 266);
            this.paymntSourceGrpBox.TabIndex = 3;
            this.paymntSourceGrpBox.TabStop = false;
            this.paymntSourceGrpBox.Text = "Payment Sources";
            // 
            // loadText
            // 
            this.loadText.AutoSize = true;
            this.loadText.ForeColor = System.Drawing.Color.Red;
            this.loadText.Location = new System.Drawing.Point(6, 238);
            this.loadText.Name = "loadText";
            this.loadText.Size = new System.Drawing.Size(246, 25);
            this.loadText.TabIndex = 4;
            this.loadText.Text = "Loading Payment Sources ...";
            this.loadText.Visible = false;
            // 
            // GetPaySourceBT
            // 
            this.GetPaySourceBT.BackColor = System.Drawing.Color.DodgerBlue;
            this.GetPaySourceBT.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetPaySourceBT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GetPaySourceBT.Location = new System.Drawing.Point(11, 32);
            this.GetPaySourceBT.Name = "GetPaySourceBT";
            this.GetPaySourceBT.Size = new System.Drawing.Size(478, 44);
            this.GetPaySourceBT.TabIndex = 3;
            this.GetPaySourceBT.Text = "Get Payment Sources";
            this.GetPaySourceBT.UseVisualStyleBackColor = false;
            this.GetPaySourceBT.Click += new System.EventHandler(this.GetPaySourceBT_Click);
            // 
            // savePref
            // 
            this.savePref.BackColor = System.Drawing.Color.DodgerBlue;
            this.savePref.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePref.ForeColor = System.Drawing.SystemColors.ControlText;
            this.savePref.Location = new System.Drawing.Point(7, 518);
            this.savePref.Name = "savePref";
            this.savePref.Size = new System.Drawing.Size(495, 44);
            this.savePref.TabIndex = 4;
            this.savePref.Text = "Save Preferences";
            this.savePref.UseVisualStyleBackColor = false;
            this.savePref.Click += new System.EventHandler(this.savePref_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.paypalUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.paypalPwd);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PayPal Credentials";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "PayPal Username";
            // 
            // paypalUsername
            // 
            this.paypalUsername.Location = new System.Drawing.Point(175, 34);
            this.paypalUsername.Name = "paypalUsername";
            this.paypalUsername.Size = new System.Drawing.Size(191, 20);
            this.paypalUsername.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.amountTxtBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.sendUser);
            this.groupBox2.Location = new System.Drawing.Point(7, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 132);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amount :  $";
            // 
            // amountTxtBox
            // 
            this.amountTxtBox.Location = new System.Drawing.Point(120, 101);
            this.amountTxtBox.Name = "amountTxtBox";
            this.amountTxtBox.Size = new System.Drawing.Size(171, 20);
            this.amountTxtBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username of person you are sending money to: ";
            // 
            // sendUser
            // 
            this.sendUser.Location = new System.Drawing.Point(11, 54);
            this.sendUser.Name = "sendUser";
            this.sendUser.Size = new System.Drawing.Size(296, 20);
            this.sendUser.TabIndex = 3;
            // 
            // schedGrpBox
            // 
            this.schedGrpBox.Controls.Add(this.label6);
            this.schedGrpBox.Controls.Add(this.dayMonthTxtBox);
            this.schedGrpBox.Controls.Add(this.label5);
            this.schedGrpBox.Controls.Add(this.taskNameTxtBox);
            this.schedGrpBox.Controls.Add(this.jobSchedBt);
            this.schedGrpBox.Enabled = false;
            this.schedGrpBox.Location = new System.Drawing.Point(12, 568);
            this.schedGrpBox.Name = "schedGrpBox";
            this.schedGrpBox.Size = new System.Drawing.Size(490, 138);
            this.schedGrpBox.TabIndex = 7;
            this.schedGrpBox.TabStop = false;
            this.schedGrpBox.Text = "Schedule Options :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Day Of Month :";
            // 
            // dayMonthTxtBox
            // 
            this.dayMonthTxtBox.Location = new System.Drawing.Point(151, 56);
            this.dayMonthTxtBox.Name = "dayMonthTxtBox";
            this.dayMonthTxtBox.Size = new System.Drawing.Size(191, 20);
            this.dayMonthTxtBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Task Name : ";
            // 
            // taskNameTxtBox
            // 
            this.taskNameTxtBox.Location = new System.Drawing.Point(130, 19);
            this.taskNameTxtBox.Name = "taskNameTxtBox";
            this.taskNameTxtBox.Size = new System.Drawing.Size(191, 20);
            this.taskNameTxtBox.TabIndex = 9;
            // 
            // jobSchedBt
            // 
            this.jobSchedBt.BackColor = System.Drawing.Color.DodgerBlue;
            this.jobSchedBt.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobSchedBt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.jobSchedBt.Location = new System.Drawing.Point(6, 82);
            this.jobSchedBt.Name = "jobSchedBt";
            this.jobSchedBt.Size = new System.Drawing.Size(478, 44);
            this.jobSchedBt.TabIndex = 8;
            this.jobSchedBt.Text = "Schedule Job";
            this.jobSchedBt.UseVisualStyleBackColor = false;
            this.jobSchedBt.Click += new System.EventHandler(this.jobSchedBt_Click);
            // 
            // configForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 714);
            this.Controls.Add(this.schedGrpBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.savePref);
            this.Controls.Add(this.paymntSourceGrpBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "configForm";
            this.Text = "PayPal Recurring Payment Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.paymntSourceGrpBox.ResumeLayout(false);
            this.paymntSourceGrpBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.schedGrpBox.ResumeLayout(false);
            this.schedGrpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paypalPwd;
        private System.Windows.Forms.GroupBox paymntSourceGrpBox;
        private System.Windows.Forms.Button savePref;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox paypalUsername;
        private System.Windows.Forms.Button GetPaySourceBT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amountTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sendUser;
        private System.Windows.Forms.Label loadText;
        private System.Windows.Forms.GroupBox schedGrpBox;
        private System.Windows.Forms.Button jobSchedBt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox taskNameTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dayMonthTxtBox;
    }
}

