using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tiny = TinyLibrary.Tiny;

namespace TinyAnalyse
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 词法分析器结果
		/// </summary>
		List<Tiny.Token> TokenList;

		private void OpenFileButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "TINY 源代码|*.tiny";
			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				InputTextBox.Text = File.ReadAllText(dlg.FileName);
			}
		}

		private void LoadTestCodeButton_Click(object sender, EventArgs e)
		{
			InputTextBox.Text = "{This is a test.}\r\nread x;\r\nif 0 < x then\r\n  fact := 1;\r\n  repeat\r\n    fact := fact * x;\r\n    x := x - 1\r\n    until x = 0;\r\n  write fact\r\nend";
		}

		private void LexerButton_Click(object sender, EventArgs e)
		{
			LexerResultListView.Items.Clear();
			TokenList = Tiny.Lexer.GetResult(InputTextBox.Text);
			LexerResultListView.Items.AddRange(
				TokenList.Select(x =>
					new ListViewItem(new string[] 
					{ 
						x.Row.ToString(),
						x.Col.ToString(),
						x.Type.ToString(),
						x.Value 
					})).ToArray());
			ResultTabControl.SelectedIndex = 0;
			int count = TokenList.Where(token => token.Type == Tiny.TokenType.Error).Count();
			if (count != 0)
			{
				string msg = string.Format("此法分析过程中发现{0}处错误，详见分析结果", count);
				MessageBox.Show(msg);
			}
		}

		private void GrammarButton_Click(object sender, EventArgs e)
		{
			if (TokenList == null)
			{
				MessageBox.Show("请先进行词法分析，然后再进行语法分析");
				return;
			}
			else
			{
				if (TokenList.Count == 0)
				{
					MessageBox.Show("词法分析不包含任何结果，无法进行语法分析");
					return;
				}
				else if (TokenList.Any(x => x.Type == Tiny.TokenType.Error))
				{
					MessageBox.Show("词法分析结果中包含错误Token");
					return;
				}
			}
			Tiny.Grammar grammar = new Tiny.Grammar();
			try
			{
				ResultTabControl.SelectedIndex = 1;
				Tiny.TINYNode root;
				Tiny.Token error;
				bool correct = grammar.Analyse(TokenList, out root, out error);
				if (correct)
				{
					ViewGrammarTree(root);
					MessageBox.Show("没有发现语法错误，已生成语法树");
				}
				else
				{
					ViewGrammarTree(root);
					string msg = string.Format("第{0}行，第{1}列发现语法错误",
						error.Row, error.Col, error.Value);
					MessageBox.Show(msg);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ViewGrammarTree(Tiny.TINYNode root)
		{
			GrammarResultTreeView.Nodes.Clear();
			GrammarResultTreeView.Nodes.Add(helpTree(root));
			GrammarResultTreeView.ExpandAll();
		}

		private TreeNode helpTree(Tiny.TINYNode root)
		{
			TreeNode node = new TreeNode(root.NTData);
			foreach (var child in root.Children)
			{
				node.Nodes.Add(helpTree(child));
			}
			return node;
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			InputTextBox.Clear();
		}
	}
}