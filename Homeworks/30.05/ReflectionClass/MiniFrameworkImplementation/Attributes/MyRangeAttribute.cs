namespace ReflectionClass.MiniFrameworkImplementation.Attributes;

public class MyRangeAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public MyRangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}