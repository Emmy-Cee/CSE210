using System;

public abstract class Goal
{
    private string _shortname;
    private string _description;
    private int _points;

    protected string Name => _shortname;
    protected string Description => _description;
    protected int Points => _points;

    public Goal(string name, string description, int points)
    {
        _shortname = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {Name} ({Description})";
    }
    public abstract string GetStringRepresentation();
}