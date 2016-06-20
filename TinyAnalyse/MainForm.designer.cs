namespace TinyAnalyse
{
	partial class MainForm
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainToolStrip = new System.Windows.Forms.ToolStrip();
			this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
			this.LoadTestCodeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.LexerButton = new System.Windows.Forms.ToolStripButton();
			this.GrammarButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ClearButton = new System.Windows.Forms.ToolStripButton();
			this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.InputTextBox = new System.Windows.Forms.TextBox();
			this.ResultTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.LexerResultListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.GrammarResultTreeView = new System.Windows.Forms.TreeView();
			this.MainToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
			this.MainSplitContainer.Panel1.SuspendLayout();
			this.MainSplitContainer.Panel2.SuspendLayout();
			this.MainSplitContainer.SuspendLayout();
			this.ResultTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainToolStrip
			// 
			this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileButton,
            this.LoadTestCodeButton,
            this.toolStripSeparator1,
            this.LexerButton,
            this.GrammarButton,
            this.toolStripSeparator2,
            this.ClearButton});
			this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.MainToolStrip.Name = "MainToolStrip";
			this.MainToolStrip.Size = new System.Drawing.Size(533, 25);
			this.MainToolStrip.TabIndex = 0;
			this.MainToolStrip.Text = "toolStrip1";
			// 
			// OpenFileButton
			// 
			this.OpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
			this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenFileButton.Name = "OpenFileButton";
			this.OpenFileButton.Size = new System.Drawing.Size(99, 22);
			this.OpenFileButton.Text = "打开TINY源文件";
			this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
			// 
			// LoadTestCodeButton
			// 
			this.LoadTestCodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LoadTestCodeButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadTestCodeButton.Image")));
			this.LoadTestCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LoadTestCodeButton.Name = "LoadTestCodeButton";
			this.LoadTestCodeButton.Size = new System.Drawing.Size(111, 22);
			this.LoadTestCodeButton.Text = "加载测试TINY代码";
			this.LoadTestCodeButton.Click += new System.EventHandler(this.LoadTestCodeButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// LexerButton
			// 
			this.LexerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LexerButton.Image = ((System.Drawing.Image)(resources.GetObject("LexerButton.Image")));
			this.LexerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LexerButton.Name = "LexerButton";
			this.LexerButton.Size = new System.Drawing.Size(59, 22);
			this.LexerButton.Text = "词法分析";
			this.LexerButton.Click += new System.EventHandler(this.LexerButton_Click);
			// 
			// GrammarButton
			// 
			this.GrammarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.GrammarButton.Image = ((System.Drawing.Image)(resources.GetObject("GrammarButton.Image")));
			this.GrammarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.GrammarButton.Name = "GrammarButton";
			this.GrammarButton.Size = new System.Drawing.Size(59, 22);
			this.GrammarButton.Text = "语法分析";
			this.GrammarButton.Click += new System.EventHandler(this.GrammarButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ClearButton
			// 
			this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ClearButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearButton.Image")));
			this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(59, 22);
			this.ClearButton.Text = "清空输入";
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// MainSplitContainer
			// 
			this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainSplitContainer.Location = new System.Drawing.Point(0, 25);
			this.MainSplitContainer.Name = "MainSplitContainer";
			this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// MainSplitContainer.Panel1
			// 
			this.MainSplitContainer.Panel1.Controls.Add(this.InputTextBox);
			// 
			// MainSplitContainer.Panel2
			// 
			this.MainSplitContainer.Panel2.Controls.Add(this.ResultTabControl);
			this.MainSplitContainer.Size = new System.Drawing.Size(533, 305);
			this.MainSplitContainer.SplitterDistance = 177;
			this.MainSplitContainer.TabIndex = 1;
			// 
			// InputTextBox
			// 
			this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputTextBox.Location = new System.Drawing.Point(0, 0);
			this.InputTextBox.Multiline = true;
			this.InputTextBox.Name = "InputTextBox";
			this.InputTextBox.Size = new System.Drawing.Size(533, 177);
			this.InputTextBox.TabIndex = 0;
			// 
			// ResultTabControl
			// 
			this.ResultTabControl.Controls.Add(this.tabPage1);
			this.ResultTabControl.Controls.Add(this.tabPage2);
			this.ResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultTabControl.Location = new System.Drawing.Point(0, 0);
			this.ResultTabControl.Name = "ResultTabControl";
			this.ResultTabControl.SelectedIndex = 0;
			this.ResultTabControl.Size = new System.Drawing.Size(533, 124);
			this.ResultTabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.LexerResultListView);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(525, 98);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "词法分析结果";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// LexerResultListView
			// 
			this.LexerResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.LexerResultListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LexerResultListView.Location = new System.Drawing.Point(3, 3);
			this.LexerResultListView.Name = "LexerResultListView";
			this.LexerResultListView.Size = new System.Drawing.Size(519, 92);
			this.LexerResultListView.TabIndex = 0;
			this.LexerResultListView.UseCompatibleStateImageBehavior = false;
			this.LexerResultListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "行号";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "列号";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Token类型";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Token值";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.GrammarResultTreeView);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(525, 98);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "语法分析结果";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// GrammarResultTreeView
			// 
			this.GrammarResultTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrammarResultTreeView.Location = new System.Drawing.Point(3, 3);
			this.GrammarResultTreeView.Name = "GrammarResultTreeView";
			this.GrammarResultTreeView.Size = new System.Drawing.Size(519, 92);
			this.GrammarResultTreeView.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 330);
			this.Controls.Add(this.MainSplitContainer);
			this.Controls.Add(this.MainToolStrip);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TINY 源代码分析器";
			this.MainToolStrip.ResumeLayout(false);
			this.MainToolStrip.PerformLayout();
			this.MainSplitContainer.Panel1.ResumeLayout(false);
			this.MainSplitContainer.Panel1.PerformLayout();
			this.MainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
			this.MainSplitContainer.ResumeLayout(false);
			this.ResultTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip MainToolStrip;
		private System.Windows.Forms.ToolStripButton OpenFileButton;
		private System.Windows.Forms.ToolStripButton LoadTestCodeButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton LexerButton;
		private System.Windows.Forms.ToolStripButton GrammarButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton ClearButton;
		private System.Windows.Forms.SplitContainer MainSplitContainer;
		private System.Windows.Forms.TextBox InputTextBox;
		private System.Windows.Forms.TabControl ResultTabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView LexerResultListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TreeView GrammarResultTreeView;
	}
}

