using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public enum NTVTType
	{
		#region 非终结符
		Program,
		STMTSequence,
		STMT_,
		Statement,
		IfSTMT,
		ElseSTMT,
		RepeatSTMT,
		AssignSTMT,
		ReadSTMT,
		WriteSTMT,
		Exp,
		CmpExp_,
		ComparisionOp,
		SimpleExp,
		Term_,
		AddOp,
		Term,
		Factor_,
		MulOp,
		Factor,
		#endregion

		#region 终结符 或 ε
		If,
		Then,
		Else,
		End,
		Repeat,
		Until,
		Read,
		Write,
		Plus,
		Minus,
		Mul,
		Div,
		Equal,
		LessThan,
		Assign,
		Semicolon,
		LeftBracket,
		RightBracket,
		Identifier,
		Number,
		ε,
		θ
		#endregion
	}
}
