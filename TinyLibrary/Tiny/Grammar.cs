using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class Grammar
	{
		public Grammar()
		{
			Init();
		}

		private void Init()
		{
			loadRules();
			initFirst();
			initFollow();
			makeLL1List();
		}

		/// <summary>
		/// TINY文法列表
		/// </summary>
		private List<Rule> TINYRules;

		/// <summary>
		/// LL1分析列表
		/// </summary>
		private List<LL1Item> LL1ItemList;

		private NTType Start = NTType.Program;

		private Dictionary<NTType, HashSet<VTType>> firstSet;
		private Dictionary<NTType, HashSet<VTType>> followSet;

		private void loadRules()
		{
			TINYRules = new List<Rule>();
			string[] lines =TinyResource.TINYRules.Split(new string[] { "\r\n" },
				StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				string[] words = line.Split(',').ToArray();
				Rule rule = new Rule(toNT(words[0]));
				for (int i = 1; i < words.Length; i++)
				{
					rule.Words.Add(toNTVT(words[i]));
				}
				TINYRules.Add(rule);
			}
//#if DEBUG
//			Debug.WriteLine("-------------以下展示规则-----------------------");
//			Debug.WriteLine("一共有{0}条规则", TINYRules.Count);
//			foreach (var rule in TINYRules)
//			{
//				Debug.Write(string.Format("{0}  -->  ", rule.Start.ToString()));
//				foreach (var word in rule.Words)
//				{
//					Debug.Write(string.Format("{0} ", word.ToString()));
//				}
//				Debug.Write(Environment.NewLine);
//			}
//			Debug.WriteLine("-------------结束展示规则-----------------------");
//#endif
		}

		private void initFirst()
		{
			firstSet = new Dictionary<NTType, HashSet<VTType>>();
			string[] lines = TinyResource.TINYFirst.Split(new string[] { "\r\n" },
				StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				List<string> words = line.Split(',').ToList();
				string S = words[0];
				words.RemoveAt(0);
				HashSet<VTType> H = new HashSet<VTType>(words.Select(v => toVT(v)));
				firstSet.Add(toNT(S), H);
			}
//#if DEBUG
//			Debug.WriteLine("-------------以下展示First集-----------------------");
//			foreach (var item in firstSet)
//			{
//				Debug.Write(item.Key);
//				Debug.Write("\t:\t");
//				foreach (var word in item.Value)
//				{
//					Debug.Write(word);
//					Debug.Write(" ");
//				}
//				Debug.Write(Environment.NewLine);
//			}
//			Debug.WriteLine("-------------结束展示First集-----------------------");
//#endif
		}

		private void initFollow()
		{
			followSet = new Dictionary<NTType, HashSet<VTType>>();
			string[] lines = TinyResource.TINYFollow.Split(new string[] { "\r\n" },
				StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				List<string> words = line.Split(',').ToList();
				string S = words[0];
				words.RemoveAt(0);
				HashSet<VTType> H = new HashSet<VTType>(words.Select(v => toVT(v)));
				followSet.Add(toNT(S), H);
			}
//#if DEBUG
//			Debug.WriteLine("-------------以下展示Follow集-----------------------");
//			foreach (var item in followSet)
//			{
//				Debug.Write(item.Key);
//				Debug.Write("\t:\t");
//				foreach (var word in item.Value)
//				{
//					Debug.Write(word);
//					Debug.Write(" ");
//				}
//				Debug.Write(Environment.NewLine);
//			}
//			Debug.WriteLine("-------------结束展示Follow集-----------------------");
//#endif
		}

		private void makeLL1List()
		{
			LL1ItemList = new List<LL1Item>();
			foreach (var rule in TINYRules)
			{
				if (rule.Words.Contains(NTVTType.ε))//规则包含ε,即 A -> ε
				{
					foreach (var word in followSet[rule.Start])
					{
						LL1Item cell = new LL1Item();
						cell.NT = rule.Start;
						cell.meet = word;
						cell.Rule.AddRange(rule.Words);
						LL1ItemList.Add(cell);
					}
				}
				else if (isNT(rule.Words[0]))// A -> BC
				{
					foreach (var word in firstSet[toNT(rule.Words[0])].Where(v => v != VTType.ε))
					{
						LL1Item cell = new LL1Item();
						cell.NT = rule.Start;
						cell.meet = word;
						cell.Rule.AddRange(rule.Words);
						LL1ItemList.Add(cell);
					}
					if (firstSet[toNT(rule.Words[0])].Contains(VTType.ε))
					{
						foreach (var word in followSet[rule.Start])
						{
							LL1Item cell = new LL1Item();
							cell.NT = rule.Start;
							cell.meet = word;
							cell.Rule.AddRange(rule.Words);
							LL1ItemList.Add(cell);
						}
					}
				}
				else// A -> bC
				{
					LL1Item cell = new LL1Item();
					cell.NT = rule.Start;
					cell.meet = toVT(rule.Words[0]);
					cell.Rule.AddRange(rule.Words);
					LL1ItemList.Add(cell);
				}
			}
//#if DEBUG
//			Debug.WriteLine("-----------------以下展示LL1List------------------------");
//			Debug.WriteLine("LL1List共有{0}条记录", LL1ItemList.Count);
//			foreach (var item in LL1ItemList)
//			{
//				Debug.Write(string.Format("[{0},{1}] -> ", item.NT.ToString(), item.meet.ToString()));
//				foreach (var subitem in item.Rule)
//				{
//					Debug.Write(subitem);
//					Debug.Write(" ");
//				}
//				Debug.Write(Environment.NewLine);
//			}
//			Debug.WriteLine("-----------------结束展示LL1List------------------------");
//#endif
		}

		/// <summary>
		/// 分析输入串
		/// 若输入串能构成正确语法树，返回True，否则返回False
		/// </summary>
		/// <param name="TokenList">输入串</param>
		/// <param name="Root">语法树根节点</param>
		/// <returns>若输入串能构成正确语法树，返回True，否则返回False</returns>
		public bool Analyse(List<Token> TokenList, out TINYNode Root, out Token ErrorToken)
		{
			if (TokenList.Count == 0)
				throw new Exception("输入穿中不不包含任何token");
			if (TokenList.Any(token => token.Type == TokenType.Error))
				throw new Exception("请先处理词法分析中发现的错误");

			Stack<NTVTType> NTVTStack = new Stack<NTVTType>();
			Stack<TINYNode> NodeStack = new Stack<TINYNode>();
			NTVTStack.Push(toNTVT(Start));
			Root = new TINYNode(Start.ToString());
			ErrorToken = null;
			NodeStack.Push(Root);

			int index = 0;
			NTVTType X;//栈顶元素
			TINYNode curNode;//栈顶节点
			VTType a;//当前输入

			while (NTVTStack.Count != 0)
			{
				X = NTVTStack.Peek();//栈顶元素
				curNode = NodeStack.Peek();//栈顶节点

				if (index < TokenList.Count)
					a = toVT(TokenList[index].Type.ToString());
				else
					a = VTType.θ;

				if (X.ToString() == a.ToString())//当前元素等于栈顶元素
				{
					NTVTStack.Pop();
					NodeStack.Pop();
					index++;
				}
				else if (isNT(X))//当前元素不等于栈顶元素X，但是栈顶元素X是非终结符
				{
					LL1Item L = find(toNT(X), a);
					if (L == null)//没有找到[X,a]
					{
						if (existX(toNT(X)))//X可以归结为ε
						{
							curNode.Children.Add(new TINYNode("ε"));
							NTVTStack.Pop();
							NodeStack.Pop();
						}
						else
						{
							curNode.Children.Add(new TINYNode(string.Format("Error")));
							ErrorToken = TokenList[index];
							return false;
						}
					}
					else //L!=null
					{
						NTVTStack.Pop();
						NodeStack.Pop();
						if (L.Rule.Contains(NTVTType.ε))// A -> ε
						{
							curNode.Children.Add(new TINYNode("ε"));
							continue;
						}
						for (int i = L.Rule.Count - 1; i >= 0; i--)
						{
							NTVTStack.Push(L.Rule[i]);

							TINYNode newNode = new TINYNode(L.Rule[i].ToString());
							NodeStack.Push(newNode);
							curNode.Children.Insert(0, newNode);
						}
					}
				}
				else
				{
					ErrorToken = TokenList[index];
					return false;
				}
			}
//#if DEBUG
//			Root.Show(1);
//#endif
			return true;
		}

		private bool isNT(NTVTType ntvt)
		{
			NTType data;
			return Enum.TryParse<NTType>(ntvt.ToString(), out data);
		}

		private NTType toNT(string data)
		{
			return (NTType)Enum.Parse(typeof(NTType), data);
		}
		private NTType toNT(NTVTType ntvt)
		{
			return (NTType)Enum.Parse(typeof(NTType), ntvt.ToString());
		}

		private VTType toVT(string data)
		{
			return (VTType)Enum.Parse(typeof(VTType), data);
		}
		private VTType toVT(NTVTType ntvt)
		{
			return (VTType)Enum.Parse(typeof(VTType), ntvt.ToString());
		}

		private NTVTType toNTVT(string data)
		{
			return (NTVTType)Enum.Parse(typeof(NTVTType), data);
		}

		private NTVTType toNTVT(TokenType vt)
		{
			return (NTVTType)Enum.Parse(typeof(NTVTType), vt.ToString());
		}
		private NTVTType toNTVT(NTType nt)
		{
			return (NTVTType)Enum.Parse(typeof(NTVTType), nt.ToString());
		}

		private LL1Item find(NTType first, VTType second)
		{
			if (LL1ItemList.Any(v => v.NT == first && v.meet == second))
				return LL1ItemList.First(v => v.NT == first && v.meet == second);
			return null;
		}
		
		/// <summary>
		/// 若first课归结为ε，返回True，否则返回False
		/// </summary>
		/// <param name="first"></param>
		/// <returns></returns>
		private bool existX(NTType first)
		{
			return LL1ItemList.Any(v => v.NT == first
				&& v.Rule.Contains(NTVTType.ε));
		}

		class Rule
		{
			public Rule(NTType start)
			{
				_start = start;
				_words = new List<NTVTType>();
			}
			public Rule(NTType start, List<NTVTType> words)
			{
				_start = start;
				_words = new List<NTVTType>();
				_words.AddRange(words);
			}
			private NTType _start;
			public NTType Start
			{
				get
				{
					return _start;
				}
			}
			private List<NTVTType> _words;
			public List<NTVTType> Words
			{
				get
				{
					return _words;
				}
			}
		}
	}
}
