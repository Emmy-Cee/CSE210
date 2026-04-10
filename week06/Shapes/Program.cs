using System;

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle("Red", 5, 3);
        Circle circle = new Circle("Blue", 4);
        Square square = new Square("Green", 2);

        List<Shapes> shapes = new List<Shapes>();
        shapes.Add(rectangle);
        shapes.Add(circle);
        shapes.Add(square);

        foreach (Shapes shape in shapes)
        {
            DisplayArea(shape);
        }
    }

    public static void DisplayArea(Shapes shape)
    {
        double area = shape.GetArea();
        string name = shape.GetName();
        string color = shape.GetColor();
        Console.WriteLine($"The area of the {color} {name} is: {area}");
    }
}