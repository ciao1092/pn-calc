internal class ConstExpr(double value) : Expr
{
	public readonly double Value = value;
	public override T Receive<T>(IVisitor<T> visitor) => visitor.Visit(this);
}
