namespace BBQstore
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.业务管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下架商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.搜索商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户评价管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Maroon;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息管理ToolStripMenuItem,
            this.业务管理ToolStripMenuItem,
            this.商品管理ToolStripMenuItem,
            this.用户反馈ToolStripMenuItem,
            this.退出登录ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 个人信息管理ToolStripMenuItem
            // 
            this.个人信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.注销账号ToolStripMenuItem});
            this.个人信息管理ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.个人信息管理ToolStripMenuItem.Name = "个人信息管理ToolStripMenuItem";
            this.个人信息管理ToolStripMenuItem.Size = new System.Drawing.Size(165, 34);
            this.个人信息管理ToolStripMenuItem.Text = "个人信息管理";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 注销账号ToolStripMenuItem
            // 
            this.注销账号ToolStripMenuItem.Name = "注销账号ToolStripMenuItem";
            this.注销账号ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.注销账号ToolStripMenuItem.Text = "注销账号";
            this.注销账号ToolStripMenuItem.Click += new System.EventHandler(this.注销账号ToolStripMenuItem_Click);
            // 
            // 业务管理ToolStripMenuItem
            // 
            this.业务管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.订单管理ToolStripMenuItem,
            this.用户管理ToolStripMenuItem});
            this.业务管理ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.业务管理ToolStripMenuItem.Name = "业务管理ToolStripMenuItem";
            this.业务管理ToolStripMenuItem.Size = new System.Drawing.Size(119, 34);
            this.业务管理ToolStripMenuItem.Text = "业务管理";
            // 
            // 订单管理ToolStripMenuItem
            // 
            this.订单管理ToolStripMenuItem.Name = "订单管理ToolStripMenuItem";
            this.订单管理ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.订单管理ToolStripMenuItem.Text = "订单管理";
            this.订单管理ToolStripMenuItem.Click += new System.EventHandler(this.订单管理ToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 商品管理ToolStripMenuItem
            // 
            this.商品管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加商品ToolStripMenuItem,
            this.修改商品ToolStripMenuItem,
            this.下架商品ToolStripMenuItem,
            this.搜索商品ToolStripMenuItem});
            this.商品管理ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.商品管理ToolStripMenuItem.Name = "商品管理ToolStripMenuItem";
            this.商品管理ToolStripMenuItem.Size = new System.Drawing.Size(119, 34);
            this.商品管理ToolStripMenuItem.Text = "商品管理";
            // 
            // 添加商品ToolStripMenuItem
            // 
            this.添加商品ToolStripMenuItem.Name = "添加商品ToolStripMenuItem";
            this.添加商品ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.添加商品ToolStripMenuItem.Text = "添加商品";
            this.添加商品ToolStripMenuItem.Click += new System.EventHandler(this.添加商品ToolStripMenuItem_Click);
            // 
            // 修改商品ToolStripMenuItem
            // 
            this.修改商品ToolStripMenuItem.Name = "修改商品ToolStripMenuItem";
            this.修改商品ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.修改商品ToolStripMenuItem.Text = "修改商品";
            this.修改商品ToolStripMenuItem.Click += new System.EventHandler(this.修改商品ToolStripMenuItem_Click);
            // 
            // 下架商品ToolStripMenuItem
            // 
            this.下架商品ToolStripMenuItem.Name = "下架商品ToolStripMenuItem";
            this.下架商品ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.下架商品ToolStripMenuItem.Text = "下架商品";
            this.下架商品ToolStripMenuItem.Click += new System.EventHandler(this.下架商品ToolStripMenuItem_Click);
            // 
            // 搜索商品ToolStripMenuItem
            // 
            this.搜索商品ToolStripMenuItem.Name = "搜索商品ToolStripMenuItem";
            this.搜索商品ToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.搜索商品ToolStripMenuItem.Text = "搜索商品";
            this.搜索商品ToolStripMenuItem.Click += new System.EventHandler(this.搜索商品ToolStripMenuItem_Click);
            // 
            // 用户反馈ToolStripMenuItem
            // 
            this.用户反馈ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户评价管理ToolStripMenuItem,
            this.消息管理ToolStripMenuItem});
            this.用户反馈ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.用户反馈ToolStripMenuItem.Name = "用户反馈ToolStripMenuItem";
            this.用户反馈ToolStripMenuItem.Size = new System.Drawing.Size(119, 34);
            this.用户反馈ToolStripMenuItem.Text = "用户反馈";
            // 
            // 用户评价管理ToolStripMenuItem
            // 
            this.用户评价管理ToolStripMenuItem.Name = "用户评价管理ToolStripMenuItem";
            this.用户评价管理ToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.用户评价管理ToolStripMenuItem.Text = "用户评价管理";
            this.用户评价管理ToolStripMenuItem.Click += new System.EventHandler(this.用户评价管理ToolStripMenuItem_Click);
            // 
            // 消息管理ToolStripMenuItem
            // 
            this.消息管理ToolStripMenuItem.Name = "消息管理ToolStripMenuItem";
            this.消息管理ToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.消息管理ToolStripMenuItem.Text = "消息管理";
            this.消息管理ToolStripMenuItem.Click += new System.EventHandler(this.消息管理ToolStripMenuItem_Click);
            // 
            // 退出登录ToolStripMenuItem
            // 
            this.退出登录ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.退出登录ToolStripMenuItem.Name = "退出登录ToolStripMenuItem";
            this.退出登录ToolStripMenuItem.Size = new System.Drawing.Size(119, 34);
            this.退出登录ToolStripMenuItem.Text = "退出登录";
            this.退出登录ToolStripMenuItem.Click += new System.EventHandler(this.退出登录ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(102, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(105, 212);
            this.label2.MaximumSize = new System.Drawing.Size(900, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(898, 414);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1089, 736);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销账号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 业务管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下架商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 搜索商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户评价管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出登录ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}