public class Circle : Shapes
{
    private double _radius;
    private string _name;


    public Circle(string color, double radius)
    {
        _radius = radius;
    }

    public override string GetName()
    {
        _name = "Circle";
        return _name;
    }

    public override string GetColor()
    {
        return _color;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}