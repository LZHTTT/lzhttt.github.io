
namespace BZD
{
    partial class waizai
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(waizai));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.调用XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开控制面板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开磁盘管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑后重新载入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消固定最前ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回默认位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开自身所在目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新程序到系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件版本20210119ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(202, 342);
            this.listBox1.TabIndex = 0;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.调用XToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.软件版本20210119ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(210, 92);
            // 
            // 调用XToolStripMenuItem
            // 
            this.调用XToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开控制面板ToolStripMenuItem,
            this.打开磁盘管理ToolStripMenuItem});
            this.调用XToolStripMenuItem.Name = "调用XToolStripMenuItem";
            this.调用XToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.调用XToolStripMenuItem.Text = "调用X";
            this.调用XToolStripMenuItem.Click += new System.EventHandler(this.调用XToolStripMenuItem_Click);
            // 
            // 打开控制面板ToolStripMenuItem
            // 
            this.打开控制面板ToolStripMenuItem.Name = "打开控制面板ToolStripMenuItem";
            this.打开控制面板ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开控制面板ToolStripMenuItem.Text = "打开控制面板";
            this.打开控制面板ToolStripMenuItem.Click += new System.EventHandler(this.打开控制面板ToolStripMenuItem_Click);
            // 
            // 打开磁盘管理ToolStripMenuItem
            // 
            this.打开磁盘管理ToolStripMenuItem.Name = "打开磁盘管理ToolStripMenuItem";
            this.打开磁盘管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开磁盘管理ToolStripMenuItem.Text = "打开磁盘管理";
            this.打开磁盘管理ToolStripMenuItem.Click += new System.EventHandler(this.打开磁盘管理ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.编辑后重新载入ToolStripMenuItem,
            this.取消固定最前ToolStripMenuItem,
            this.返回默认位置ToolStripMenuItem,
            this.打开自身所在目录ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.显示ToolStripMenuItem.Text = "内容与显示";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 编辑后重新载入ToolStripMenuItem
            // 
            this.编辑后重新载入ToolStripMenuItem.Name = "编辑后重新载入ToolStripMenuItem";
            this.编辑后重新载入ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.编辑后重新载入ToolStripMenuItem.Text = "重新载入";
            this.编辑后重新载入ToolStripMenuItem.Click += new System.EventHandler(this.编辑后重新载入ToolStripMenuItem_Click);
            // 
            // 取消固定最前ToolStripMenuItem
            // 
            this.取消固定最前ToolStripMenuItem.Name = "取消固定最前ToolStripMenuItem";
            this.取消固定最前ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.取消固定最前ToolStripMenuItem.Text = "取消固定最前";
            this.取消固定最前ToolStripMenuItem.Click += new System.EventHandler(this.取消固定最前ToolStripMenuItem_Click);
            // 
            // 返回默认位置ToolStripMenuItem
            // 
            this.返回默认位置ToolStripMenuItem.Name = "返回默认位置ToolStripMenuItem";
            this.返回默认位置ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.返回默认位置ToolStripMenuItem.Text = "返回默认位置";
            this.返回默认位置ToolStripMenuItem.Click += new System.EventHandler(this.返回默认位置ToolStripMenuItem_Click);
            // 
            // 打开自身所在目录ToolStripMenuItem
            // 
            this.打开自身所在目录ToolStripMenuItem.Name = "打开自身所在目录ToolStripMenuItem";
            this.打开自身所在目录ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.打开自身所在目录ToolStripMenuItem.Text = "打开软件自身目录";
            this.打开自身所在目录ToolStripMenuItem.Click += new System.EventHandler(this.打开自身所在目录ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新程序到系统ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 更新程序到系统ToolStripMenuItem
            // 
            this.更新程序到系统ToolStripMenuItem.Name = "更新程序到系统ToolStripMenuItem";
            this.更新程序到系统ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更新程序到系统ToolStripMenuItem.Text = "更新程序到系统";
            this.更新程序到系统ToolStripMenuItem.Click += new System.EventHandler(this.更新程序到系统ToolStripMenuItem_Click);
            // 
            // 软件版本20210119ToolStripMenuItem
            // 
            this.软件版本20210119ToolStripMenuItem.Name = "软件版本20210119ToolStripMenuItem";
            this.软件版本20210119ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.软件版本20210119ToolStripMenuItem.Text = "软件版本：20210122.13";
            this.软件版本20210119ToolStripMenuItem.Click += new System.EventHandler(this.软件版本20210119ToolStripMenuItem_Click);
            // 
            // waizai
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 341);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 39);
            this.Name = "waizai";
            this.ShowInTaskbar = false;
            this.Text = "✨✨✨✨✨✨";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.waizai_Activated);
            this.Deactivate += new System.EventHandler(this.waizai_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.waizai_FormClosing);
            this.Load += new System.EventHandler(this.waizai_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调用XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件版本20210119ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新程序到系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消固定最前ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开控制面板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开磁盘管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 返回默认位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑后重新载入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开自身所在目录ToolStripMenuItem;
    }
}