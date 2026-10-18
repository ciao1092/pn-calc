
internal class TreeToStringInator : IVisitor<string>
{
	public string GetPrintableTree(Expr e) => e.Receive(this);

	string IVisitor<string>.Visit(ConstExpr expr) => $"{expr.Value}";

	string IVisitor<string>.Visit(BinaryExpr expr)
	{
		return $"({expr.Left.Receive(this)}{expr.Operator.AsString}{expr.Right.Receive(this)})";
	}
}
