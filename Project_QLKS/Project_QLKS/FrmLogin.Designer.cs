namespace Project_QLKS
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_TenDN = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_TenTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_MK = new System.Windows.Forms.TextBox();
            this.bt_DN = new System.Windows.Forms.Button();
            this.bt_Thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(43, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // lb_TenDN
            // 
            this.lb_TenDN.AutoSize = true;
            this.lb_TenDN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenDN.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_TenDN.Location = new System.Drawing.Point(12, 200);
            this.lb_TenDN.Name = "lb_TenDN";
            this.lb_TenDN.Size = new System.Drawing.Size(107, 20);
            this.lb_TenDN.TabIndex = 2;
            this.lb_TenDN.Text = "Tên đăng nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.ForeColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(128, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 1);
            this.panel1.TabIndex = 3;
            // 
            // tb_TenTK
            // 
            this.tb_TenTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tb_TenTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_TenTK.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TenTK.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_TenTK.Location = new System.Drawing.Point(127, 197);
            this.tb_TenTK.Name = "tb_TenTK";
            this.tb_TenTK.Size = new System.Drawing.Size(168, 20);
            this.tb_TenTK.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.ForeColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(127, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 1);
            this.panel2.TabIndex = 4;
            // 
            // tb_MK
            // 
            this.tb_MK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.tb_MK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_MK.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MK.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_MK.Location = new System.Drawing.Point(127, 253);
            this.tb_MK.Name = "tb_MK";
            this.tb_MK.PasswordChar = '*';
            this.tb_MK.Size = new System.Drawing.Size(170, 20);
            this.tb_MK.TabIndex = 6;
            // 
            // bt_DN
            // 
            this.bt_DN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(168)))), ((int)(((byte)(231)))));
            this.bt_DN.FlatAppearance.BorderSize = 0;
            this.bt_DN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_DN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DN.ForeColor = System.Drawing.SystemColors.Window;
            this.bt_DN.Location = new System.Drawing.Point(16, 348);
            this.bt_DN.Name = "bt_DN";
            this.bt_DN.Size = new System.Drawing.Size(130, 36);
            this.bt_DN.TabIndex = 7;
            this.bt_DN.Text = "Đăng nhập";
            this.bt_DN.UseVisualStyleBackColor = false;
            this.bt_DN.Click += new System.EventHandler(this.bt_DN_Click);
            // 
            // bt_Thoat
            // 
            this.bt_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(168)))), ((int)(((byte)(231)))));
            this.bt_Thoat.FlatAppearance.BorderSize = 0;
            this.bt_Thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Thoat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Thoat.ForeColor = System.Drawing.SystemColors.Window;
            this.bt_Thoat.Location = new System.Drawing.Point(167, 348);
            this.bt_Thoat.Name = "bt_Thoat";
            this.bt_Thoat.Size = new System.Drawing.Size(130, 36);
            this.bt_Thoat.TabIndex = 8;
            this.bt_Thoat.Text = "Thoát";
            this.bt_Thoat.UseVisualStyleBackColor = false;
            this.bt_Thoat.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(315, 415);
            this.Controls.Add(this.bt_Thoat);
            this.Controls.Add(this.bt_DN);
            this.Controls.Add(this.tb_MK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_TenTK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_TenDN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_TenDN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_TenTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_MK;
        private System.Windows.Forms.Button bt_DN;
        private System.Windows.Forms.Button bt_Thoat;
    }
}