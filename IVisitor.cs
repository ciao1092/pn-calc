internal interface IVisitor<T>
{
	T Visit(ConstExpr expr);
	T Visit(BinaryExpr expr);
}