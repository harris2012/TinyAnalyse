using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class Definition
	{
		private static readonly char[] _character = 
		{
			'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
			'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
			'0','1','2','3','4','5','6','7','8','9',
			'+','-','*','/','=',':',
			';','(',')','{','}','#'
		};

		private static readonly string[] _keyword = 
		{
			"if","then","else","end","repeat","until","read","write"
		};

		public static TokenType GetWordType(string word)
		{
			foreach (var item in _keyword)
			{
				if (item.Equals(word))
					return (TokenType)Enum.Parse(typeof(TokenType), word, true);
			}
			return TokenType.Identifier;
		}
	}
}
