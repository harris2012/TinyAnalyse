using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class SourceReader
	{
		public SourceReader(string SourceCode)
		{
			_data = new StringBuilder(SourceCode);
			_row = 1;
			_col = 0;
		}

		private StringBuilder _data;

		private int _row, _col;

		public char Read()
		{
			if (_data.Length == 0)
				return '\0';
			char ch = _data[0];
			if (ch == '\r')
				_col = 0;
			else if (ch == '\n')
				_row++;
			else
				_col++;
			_data.Remove(0, 1);
			return ch;
		}

		public char ViewOne()
		{
			if (_data.Length == 0)
				return '\0';
			return _data[0];
		}

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
	}
}
