using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class TINYNode
	{
		public TINYNode()
		{
			Children = new List<TINYNode>();
		}
		public TINYNode(string data)
		{
			NTData = data;
			Children = new List<TINYNode>();
		}
		public string NTData;
		public List<TINYNode> Children;
		public void Show(int count)
		{
//#if DEBUG
//			for (int i = 0; i < count; i++)
//				Debug.Write("  ");
//			Debug.WriteLine("  " + NTData);
//			foreach (var child in Children)
//				child.Show(count + 1);
//#endif
		}
	}
}
