using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLibrary.Tiny
{
	public class Lexer
	{
		public static List<Token> GetResult(string SourceCode)
		{
			List<Token> result = new List<Token>();
			SourceReader reader = new SourceReader(SourceCode);
			char ch;
			StringBuilder token;
			int row, col;
			while ((ch = reader.Read()) != '\0')
			{
				row = reader.Row;
				col = reader.Col;
				token = new StringBuilder();
				if (isLetter(ch))
				{
					token.Append(ch);
					while ((ch = reader.ViewOne()) != '\0' && isLetterOrDigit(ch))
					{
						token.Append(ch);
						reader.Read();
					}
					string data = token.ToString();
					result.Add(new Token(row, col, Definition.GetWordType(data), data));
				}
				else if (isDigit(ch))
				{
					token.Append(ch);
					while ((ch = reader.ViewOne()) != '\0' && isDigit(ch))
					{
						token.Append(ch);
						reader.Read();
					}
					result.Add(new Token(row, col, TokenType.Number, token.ToString()));
				}
				else
					switch (ch)
					{
						case ':':
							if (reader.ViewOne() == '=')
							{
								reader.Read();
								result.Add(new Token(row, col, TokenType.Assign, ":="));
							}
							else
								result.Add(new Token(row, col, TokenType.Error, ":"));
							break;

						case '+':
							result.Add(new Token(row, col, TokenType.Plus, "+"));
							break;

						case '-':
							result.Add(new Token(row, col, TokenType.Minus, "-"));
							break;

						case '*':
							result.Add(new Token(row, col, TokenType.Mul, "*"));
							break;

						case '/':
							result.Add(new Token(row, col, TokenType.Div, "/"));
							break;

						case '=':
							result.Add(new Token(row, col, TokenType.Equal, "="));
							break;

						case '<':
							result.Add(new Token(row, col, TokenType.LessThan, "<"));
							break;

						case ';':
							result.Add(new Token(row, col, TokenType.Semicolon, ";"));
							break;

						case '(':
							result.Add(new Token(row, col, TokenType.LeftBracket, "("));
							break;
						case ')':
							result.Add(new Token(row, col, TokenType.RightBracket, ")"));
							break;
						case '{'://过滤源代码中的注释
							while (reader.ViewOne() != '\0' && reader.ViewOne() != '}')
							{
								reader.Read();
							}
							if (reader.ViewOne() == '}')
								reader.Read();
							//    result.Add(new Token(row, col, TokenType.LeftLargetBracket, "{"));
							//    break;
							//case '}':
							//    result.Add(new Token(row, col, TokenType.RightLargetBracket, "}"));
							//    break;
							//case '#':
							//    result.Add(new Token(row, col, TokenType.PoundSign, "#"));
							break;

						case ' ':
						case '\r':
						case '\n':
							break;

						default:
							result.Add(new Token(row, col, TokenType.Error, ch.ToString()));
							break;
					}
			}
			return result;
		}

		private static bool isLetter(char ch)
		{
			return ((ch >= 'A') && (ch <= 'Z'))
				|| ((ch >= 'a') && (ch <= 'z'));
		}

		private static bool isLetterOrDigit(char ch)
		{
			return ((ch >= '0') && (ch <= '9'))
				|| ((ch >= 'A') && (ch <= 'Z'))
				|| ((ch >= 'a') && (ch <= 'z'));
		}

		private static bool isDigit(char ch)
		{
			return (ch >= '0') && (ch <= '9');
		}
	}
}
