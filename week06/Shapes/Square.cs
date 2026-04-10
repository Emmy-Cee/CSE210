public class Square : Shapes
{
    private double _side;
    private string _name;


    public Square(string color, double side)
    {
        _side = side;
    }

    public override string GetName()
    {
        _name = "Square";
        return _name;
    }

    public override string GetColor()
    {
        return _color;
    }

    public override double GetArea()
    {
        return _side * _side;
    }

}