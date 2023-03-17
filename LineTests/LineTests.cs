using App.Line;

namespace LineTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ParserTest()
    {
        var (a, b) = (12, 3);
        var input = $"y = {a}x + {b}";
        var line = new Line(input);
        var expected = new Line(a, b);
        Assert.That(line, Is.EqualTo(expected));
    }

    [Test]
    public void ValidHashCodeTest()
    {
        var (a, b) = (12, 3);
        var input = $"y = {a}x + {b}";
        var line = new Line(input);
        var expected = new Line(a, b);
        Assert.That(line, Is.EqualTo(expected));
        Assert.That(line.GetHashCode(), Is.EqualTo(expected.GetHashCode()));
    }

    [Test]
    public void ValiddHashCodeTest2()
    {
        var (a, b) = (12.1, 3.4);
        var input = $"y = {a}x + {b}";
        var line = new Line(input);
        var line2 = new Line(a + 2, b - 1);
        Assert.That(line, !Is.EqualTo(line2));
        Assert.That(line.GetHashCode(), !Is.EqualTo(line2.GetHashCode()));
    }
    

    [Test]
    public void ToStringTest()
    {
        var (a, b) = (12.1, 3.4);
        var input = $"y = {a}x + {b}";
        var line = new Line(input);
        Assert.That(line.ToString(), Is.EqualTo(input));
    }
}