public class Rectangle : Shapes
{
    private double _length;
    private double _width;
    private string _name;

    public Rectangle(string color, double length, double width) 
    {
        _length = length;
        _width = width;
    }

    public override string GetName()
    {
        _name = "Rectangle";
        return _name;
    }

    public override string GetColor()
    {
        return _color;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}