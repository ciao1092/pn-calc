internal class OperatorToken(OperatorType type) : Token
{
    static readonly Dictionary<string, OperatorType> operators = new()
    {
        { "+", OperatorType.Plus },
        { "-", OperatorType.Minus },
        { "*", OperatorType.Times },
        { "/", OperatorType.Divide },
    };

    public static string? OperatorTypeToString(OperatorType type)
    {
        var x = operators.FirstOrDefault(x => x.Value == type).Key;
        return string.IsNullOrEmpty(x) ? null : x;
    }

    public static OperatorType OperatorTypeFromString(string str)
    {
        return operators.GetValueOrDefault(str);
    }

    public readonly OperatorType Type = type;

    public override string AsString => OperatorTypeToString(Type)!;
}



internal enum OperatorType
{
    Invalid,
    Times,
    Plus,
    Minus,
    Divide
}