

internal class BinaryExpr(OperatorToken op, Expr left, Expr right) : Expr
{
	public readonly OperatorToken Operator = op;
	public readonly Expr Left = left;
	public readonly Expr Right = right;
	public override T Receive<T>(IVisitor<T> visitor) => visitor.Visit(this);
}