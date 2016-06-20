using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public enum TokenType
	{
		#region 关键字
		/// <summary>
		/// if
		/// </summary>
		If,
		/// <summary>
		/// then
		/// </summary>
		Then,
		/// <summary>
		/// else
		/// </summary>
		Else,
		/// <summary>
		/// end
		/// </summary>
		End,
		/// <summary>
		/// repeat
		/// </summary>
		Repeat,
		/// <summary>
		/// until
		/// </summary>
		Until,
		/// <summary>
		/// read
		/// </summary>
		Read,
		/// <summary>
		/// write
		/// </summary>
		Write,
		#endregion

		#region 运算符
		/// <summary>
		/// +
		/// </summary>
		Plus,
		/// <summary>
		/// -
		/// </summary>
		Minus,
		/// <summary>
		/// *
		/// </summary>
		Mul,
		/// <summary>
		/// /
		/// </summary>
		Div,
		/// <summary>
		/// =
		/// </summary>
		Equal,
		/// <summary>
		/// &lt;
		/// </summary>
		LessThan,
		/// <summary>
		/// :=
		/// </summary>
		Assign,
		#endregion

		#region Separator
		/// <summary>
		/// ；
		/// </summary>
		Semicolon,
		/// <summary>
		/// （
		/// </summary>
		LeftBracket,
		/// <summary>
		/// ）
		/// </summary>
		RightBracket,
		#endregion

		/// <summary>
		/// 标识符
		/// </summary>
		Identifier,
		/// <summary>
		/// 数字
		/// </summary>
		Number,

		/// <summary>
		/// 错误
		/// </summary>
		Error

	}
}
