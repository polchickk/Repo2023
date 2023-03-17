namespace App;

public static class DoubleComparer
{
    public static bool Equals(double x, double y) => Math.Abs(x - y) < 10e-13;
}
