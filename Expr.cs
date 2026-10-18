internal abstract class Expr
{
	public abstract T Receive<T>(IVisitor<T> visitor);
}
