namespace Server
{
    partial class Form1
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
            this.serverStatusPB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.activeUsersLB = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.banBtn = new System.Windows.Forms.Button();
            this.unBanBtn = new System.Windows.Forms.Button();
            this.nameToUnbanTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messageTB = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatusPB)).BeginInit();
            this.SuspendLayout();
            // 
            // serverStatusPB
            // 
            this.serverStatusPB.Location = new System.Drawing.Point(12, 40);
            this.serverStatusPB.Name = "serverStatusPB";
            this.serverStatusPB.Size = new System.Drawing.Size(362, 194);
            this.serverStatusPB.TabIndex = 0;
            this.serverStatusPB.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Status:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 85);
            this.button1.TabIndex = 2;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 85);
            this.button2.TabIndex = 3;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // activeUsersLB
            // 
            this.activeUsersLB.FormattingEnabled = true;
            this.activeUsersLB.Location = new System.Drawing.Point(12, 322);
            this.activeUsersLB.Name = "activeUsersLB";
            this.activeUsersLB.Size = new System.Drawing.Size(308, 147);
            this.activeUsersLB.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 5;
            this.button3.Text = "Kick";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.kickBtn_Click);
            // 
            // banBtn
            // 
            this.banBtn.Location = new System.Drawing.Point(245, 241);
            this.banBtn.Name = "banBtn";
            this.banBtn.Size = new System.Drawing.Size(75, 75);
            this.banBtn.TabIndex = 6;
            this.banBtn.Text = "Ban";
            this.banBtn.UseVisualStyleBackColor = true;
            this.banBtn.Click += new System.EventHandler(this.banBtn_Click);
            // 
            // unBanBtn
            // 
            this.unBanBtn.Location = new System.Drawing.Point(461, 341);
            this.unBanBtn.Name = "unBanBtn";
            this.unBanBtn.Size = new System.Drawing.Size(51, 33);
            this.unBanBtn.TabIndex = 7;
            this.unBanBtn.Text = "Unban";
            this.unBanBtn.UseVisualStyleBackColor = true;
            this.unBanBtn.Click += new System.EventHandler(this.unBanBtn_Click);
            // 
            // nameToUnbanTB
            // 
            this.nameToUnbanTB.Location = new System.Drawing.Point(329, 348);
            this.nameToUnbanTB.Name = "nameToUnbanTB";
            this.nameToUnbanTB.Size = new System.Drawing.Size(126, 20);
            this.nameToUnbanTB.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(326, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter name to uban:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(326, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter message:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.UseMnemonic = false;
            // 
            // messageTB
            // 
            this.messageTB.Location = new System.Drawing.Point(329, 414);
            this.messageTB.Multiline = true;
            this.messageTB.Name = "messageTB";
            this.messageTB.Size = new System.Drawing.Size(126, 55);
            this.messageTB.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(461, 423);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 33);
            this.button4.TabIndex = 10;
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 481);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageTB);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameToUnbanTB);
            this.Controls.Add(this.unBanBtn);
            this.Controls.Add(this.banBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.activeUsersLB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverStatusPB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.serverStatusPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox serverStatusPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox activeUsersLB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button banBtn;
        private System.Windows.Forms.Button unBanBtn;
        private System.Windows.Forms.TextBox nameToUnbanTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox messageTB;
        private System.Windows.Forms.Button button4;
    }
}

