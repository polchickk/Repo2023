using System.Text.RegularExpressions;

namespace App.Line;

public partial struct Line
{
    private static readonly Regex expressionTemplate = new Regex(@"y = (?<A>[0-9]+[,.]?[0-9]*)x (?<B>[+-].[0-9]+[,.]?[0-9]*)", RegexOptions.Compiled);
    public double A { get; set; }
    public double B { get; set; }
    public double AngelInDegrees { get; init; } // возвращает только в методе

    public Line(double a, double b)
    {
        A = a;
        B = b;
        AngelInDegrees = Math.Atan(a) * 180 / Math.PI;
    }

    public Line(string expression)
    {
        var match = expressionTemplate.Match(expression); //соответствие выражению
        if (!match.Success)
            throw new ArgumentException("Введен неправильный формат!");
        A = double.Parse(match.Groups["A"].Value); //выбирает из группы предложенных вариантов
        B = double.Parse(match.Groups["B"].Value.Replace(" ", ""));
        AngelInDegrees = Math.Atan(A) * 180 / Math.PI;
    }
    
    public override bool Equals(object obj)
    {
        return obj.GetType() == typeof(Line) 
            && DoubleComparer.Equals(((Line)obj).A, A)
            && DoubleComparer.Equals(((Line)obj).B, B);
    }

    public override int GetHashCode() => $"{A.GetHashCode()}{B.GetHashCode()}".GetHashCode();

    public override string ToString() => $"y = {A}x {(B > 0 ? '+' : '-')} {B}";

    public static Line operator ~(Line line)
    {
        if (DoubleComparer.Equals(line.A, 0)) // параллельно х
            throw new ArgumentException("Нет перпендикулярных прямых");
        return new Line( - 1 / line.A, line.B);
    }

    public static bool operator ==(Line left, Line right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Line left, Line right)
    {
        return !(left == right);
    }
}
