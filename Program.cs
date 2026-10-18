
const string input = "/ 1 + 1 - 2000 + + 200 1789 11";
string[] parts = input.Split();

List<Token> tokens = [];

foreach (string token in parts)
{
	if (string.IsNullOrWhiteSpace(token)) continue;
	if (double.TryParse(token, out double doubleValue))
	{
		tokens.Add(new LiteralToken(doubleValue));
	}
	else
	{
		var op = OperatorToken.OperatorTypeFromString(token);
		if (op != OperatorType.Invalid)
		{
			tokens.Add(new OperatorToken(op));
		}
		else throw new($"Invalid operator: \"{token}\"");
	}
}

int currentToken = 0;
Expr getExprTree()
{
	if (currentToken >= tokens.Count)
		throw new Exception("Unexpected end of expression. Missing operands or operators.");

	var token = tokens[currentToken++];

	if (token is LiteralToken literal)
	{
		return new ConstExpr(literal.Value);
	}
	else if (token is OperatorToken operatorToken)
	{
		if (currentToken + 1 >= tokens.Count)
			throw new Exception($"Operator \"{operatorToken.AsString}\" missing operands.");


		var leftExpr = getExprTree();
		var rightExpr = getExprTree();

		return new BinaryExpr(operatorToken, leftExpr, rightExpr);
	}

	throw new Exception($"\"{token}\": invalid token");
}

var e = getExprTree();

Console.WriteLine(new TreeToStringInator().GetPrintableTree(e));

var result = new Evaluator().Evaluate(e);

Console.WriteLine(result);
