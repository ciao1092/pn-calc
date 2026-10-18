
internal class Evaluator : IVisitor<double>
{
	public double Evaluate(Expr e)
	{
		return e.Receive(this);
	}

	double IVisitor<double>.Visit(ConstExpr expr)
	{
		return expr.Value;
	}

	double IVisitor<double>.Visit(BinaryExpr expr)
	{
		double v1 = expr.Left.Receive(this);
		double v2 = expr.Right.Receive(this);
		switch (expr.Operator.Type)
		{
			case OperatorType.Times:
				return v1 * v2;
			case OperatorType.Plus:
				return v1 + v2;
			case OperatorType.Divide:
				if (v2 == 0)
					throw new DivideByZeroException("Attempted to divide by zero.");
				return v1 / v2;
			case OperatorType.Minus:
				return v1 - v2;
			default:
				throw new NotImplementedException($"{expr.Operator}: operator not implemented.");
		}
	}
}
