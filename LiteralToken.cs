internal class LiteralToken(double value) : Token
{
	public double Value = value;
	public override string AsString => Value.ToString();
}