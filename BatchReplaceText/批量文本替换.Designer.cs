namespace BatchReplaceText
{
    partial class 批量文本替换
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelSelect = new System.Windows.Forms.Button();
            this.btnReadFileList = new System.Windows.Forms.Button();
            this.btnSaveFileList = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_NewString = new System.Windows.Forms.TextBox();
            this.txtBox_oldString = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_替换块内文字 = new System.Windows.Forms.CheckBox();
            this.checkBox_完全匹配 = new System.Windows.Forms.CheckBox();
            this.checkBox_修改文本高度 = new System.Windows.Forms.CheckBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.txtBox_Layer = new System.Windows.Forms.TextBox();
            this.checkBox_指定图层 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelSelect);
            this.groupBox1.Controls.Add(this.btnReadFileList);
            this.groupBox1.Controls.Add(this.btnSaveFileList);
            this.groupBox1.Controls.Add(this.btnCancelAll);
            this.groupBox1.Controls.Add(this.btnAddFiles);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化文件";
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Location = new System.Drawing.Point(150, 204);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(113, 21);
            this.btnCancelSelect.TabIndex = 1;
            this.btnCancelSelect.Text = "删除选择";
            this.btnCancelSelect.UseVisualStyleBackColor = true;
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // btnReadFileList
            // 
            this.btnReadFileList.Location = new System.Drawing.Point(567, 204);
            this.btnReadFileList.Name = "btnReadFileList";
            this.btnReadFileList.Size = new System.Drawing.Size(89, 21);
            this.btnReadFileList.TabIndex = 1;
            this.btnReadFileList.Text = "读取文件列表";
            this.btnReadFileList.UseVisualStyleBackColor = true;
            this.btnReadFileList.Click += new System.EventHandler(this.btnReadFileList_Click);
            // 
            // btnSaveFileList
            // 
            this.btnSaveFileList.Location = new System.Drawing.Point(440, 204);
            this.btnSaveFileList.Name = "btnSaveFileList";
            this.btnSaveFileList.Size = new System.Drawing.Size(103, 21);
            this.btnSaveFileList.TabIndex = 1;
            this.btnSaveFileList.Text = "保存文件列表";
            this.btnSaveFileList.UseVisualStyleBackColor = true;
            this.btnSaveFileList.Click += new System.EventHandler(this.btnSaveFileList_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(295, 204);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(107, 21);
            this.btnCancelAll.TabIndex = 1;
            this.btnCancelAll.Text = "删除全部";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(3, 204);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(108, 21);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "添加文件";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(656, 180);
            this.checkedListBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 140);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(660, 138);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(341, 138);
            this.splitContainer2.SplitterDistance = 78;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtBox_NewString);
            this.groupBox2.Controls.Add(this.txtBox_oldString);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内容";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "替换为";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "查找内容";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_NewString
            // 
            this.txtBox_NewString.Location = new System.Drawing.Point(72, 48);
            this.txtBox_NewString.Name = "txtBox_NewString";
            this.txtBox_NewString.Size = new System.Drawing.Size(269, 21);
            this.txtBox_NewString.TabIndex = 0;
            // 
            // txtBox_oldString
            // 
            this.txtBox_oldString.Location = new System.Drawing.Point(72, 17);
            this.txtBox_oldString.Name = "txtBox_oldString";
            this.txtBox_oldString.Size = new System.Drawing.Size(269, 21);
            this.txtBox_oldString.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(215, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始替换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 52);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "替换方式";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButton2.Location = new System.Drawing.Point(115, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "静默替换";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButton1.Location = new System.Drawing.Point(20, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "开图替换";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_替换块内文字);
            this.groupBox4.Controls.Add(this.checkBox_完全匹配);
            this.groupBox4.Controls.Add(this.checkBox_修改文本高度);
            this.groupBox4.Controls.Add(this.textBox_Height);
            this.groupBox4.Controls.Add(this.txtBox_Layer);
            this.groupBox4.Controls.Add(this.checkBox_指定图层);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 134);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选项";
            // 
            // checkBox_替换块内文字
            // 
            this.checkBox_替换块内文字.AutoSize = true;
            this.checkBox_替换块内文字.Location = new System.Drawing.Point(6, 115);
            this.checkBox_替换块内文字.Name = "checkBox_替换块内文字";
            this.checkBox_替换块内文字.Size = new System.Drawing.Size(96, 16);
            this.checkBox_替换块内文字.TabIndex = 0;
            this.checkBox_替换块内文字.Text = "替换块内文字";
            this.checkBox_替换块内文字.UseVisualStyleBackColor = true;
            // 
            // checkBox_完全匹配
            // 
            this.checkBox_完全匹配.AutoSize = true;
            this.checkBox_完全匹配.Location = new System.Drawing.Point(6, 86);
            this.checkBox_完全匹配.Name = "checkBox_完全匹配";
            this.checkBox_完全匹配.Size = new System.Drawing.Size(72, 16);
            this.checkBox_完全匹配.TabIndex = 0;
            this.checkBox_完全匹配.Text = "完全匹配";
            this.checkBox_完全匹配.UseVisualStyleBackColor = true;
            // 
            // checkBox_修改文本高度
            // 
            this.checkBox_修改文本高度.AutoSize = true;
            this.checkBox_修改文本高度.Location = new System.Drawing.Point(6, 56);
            this.checkBox_修改文本高度.Name = "checkBox_修改文本高度";
            this.checkBox_修改文本高度.Size = new System.Drawing.Size(96, 16);
            this.checkBox_修改文本高度.TabIndex = 0;
            this.checkBox_修改文本高度.Text = "修改文本高度";
            this.checkBox_修改文本高度.UseVisualStyleBackColor = true;
            this.checkBox_修改文本高度.CheckedChanged += new System.EventHandler(this.checkBox_修改文本高度_CheckedChanged);
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(139, 54);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(170, 21);
            this.textBox_Height.TabIndex = 0;
            // 
            // txtBox_Layer
            // 
            this.txtBox_Layer.Location = new System.Drawing.Point(139, 21);
            this.txtBox_Layer.Name = "txtBox_Layer";
            this.txtBox_Layer.Size = new System.Drawing.Size(170, 21);
            this.txtBox_Layer.TabIndex = 0;
            // 
            // checkBox_指定图层
            // 
            this.checkBox_指定图层.AutoSize = true;
            this.checkBox_指定图层.Location = new System.Drawing.Point(6, 23);
            this.checkBox_指定图层.Name = "checkBox_指定图层";
            this.checkBox_指定图层.Size = new System.Drawing.Size(72, 16);
            this.checkBox_指定图层.TabIndex = 0;
            this.checkBox_指定图层.Text = "指定图层";
            this.checkBox_指定图层.UseVisualStyleBackColor = true;
            this.checkBox_指定图层.CheckedChanged += new System.EventHandler(this.checkBox_指定图层_CheckedChanged);
            // 
            // 批量文本替换
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 377);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "批量文本替换";
            this.Text = "批量文本替换";
            this.Load += new System.EventHandler(this.批量文本替换_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelSelect;
        private System.Windows.Forms.Button btnReadFileList;
        private System.Windows.Forms.Button btnSaveFileList;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_NewString;
        private System.Windows.Forms.TextBox txtBox_oldString;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox_替换块内文字;
        private System.Windows.Forms.CheckBox checkBox_完全匹配;
        private System.Windows.Forms.CheckBox checkBox_修改文本高度;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox txtBox_Layer;
        private System.Windows.Forms.CheckBox checkBox_指定图层;
        private System.Windows.Forms.Button button1;
    }
}