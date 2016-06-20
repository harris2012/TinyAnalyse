using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class LL1Item
	{
		public LL1Item()
		{
			Rule = new List<NTVTType>();
		}
		public NTType NT;
		public VTType meet;
		public List<NTVTType> Rule;
	}
}
