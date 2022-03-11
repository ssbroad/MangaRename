
namespace MangaRename
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowInfo = new System.Windows.Forms.TextBox();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.Check = new System.Windows.Forms.Button();
            this.Set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowInfo
            // 
            this.ShowInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowInfo.Location = new System.Drawing.Point(35, 152);
            this.ShowInfo.Multiline = true;
            this.ShowInfo.Name = "ShowInfo";
            this.ShowInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ShowInfo.Size = new System.Drawing.Size(1158, 294);
            this.ShowInfo.TabIndex = 0;
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(35, 71);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(821, 21);
            this.FolderPath.TabIndex = 1;
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Check.Location = new System.Drawing.Point(894, 69);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(95, 42);
            this.Check.TabIndex = 2;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Set
            // 
            this.Set.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set.Location = new System.Drawing.Point(1021, 69);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(95, 42);
            this.Set.TabIndex = 3;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 473);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.ShowInfo);
            this.Name = "Form1";
            this.Text = "MangaRename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ShowInfo;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button Set;
    }
}

