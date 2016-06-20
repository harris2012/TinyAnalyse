using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class Token
	{
		public Token(int row, int col, TokenType type, string value)
		{
			_row = row;
			_col = col;
			_type = type;
			_value = value;
		}

		private int _row, _col;
		private TokenType _type;
		private string _value;

		public int Row
		{
			get
			{
				return _row;
			}
		}
		public int Col
		{
			get
			{
				return _col;
			}
		}
		public TokenType Type
		{
			get
			{
				return _type;
			}
		}
		public string Value
		{
			get
			{
				return _value;
			}
		}
	}
}
