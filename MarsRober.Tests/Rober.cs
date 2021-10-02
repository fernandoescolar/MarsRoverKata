namespace MarsRober.Tests;

public record Rober(int X, int Y, Direction Direction)
{
    private const int Speed = 1;

    public Rober Execute(string input)
    {
        var current = this;
        foreach (var command in input.ToUpperInvariant())
        {
            current = current.Execute(command);
        }

        return current;
    }

    internal Rober Execute(char command)
        => command switch
                {
            'F' => MoveForward(),
            'B' => MoveBackward(),
            'R' => TurnRight(),
            'L' => TurnLeft(),
            _ => this
        };

    internal Rober MoveForward()
        => Direction switch
        {
            Direction.North => this with { Y = Y + Speed },
            Direction.South => this with { Y = Y - Speed },
            Direction.East  => this with { X = X + Speed },
            Direction.West  => this with { X = X - Speed },
            _               => throw new NotImplementedException()
        };

    internal Rober MoveBackward()
        => Direction switch
        {
            Direction.North => this with { Y = Y - Speed },
            Direction.South => this with { Y = Y + Speed },
            Direction.East  => this with { X = X - Speed },
            Direction.West  => this with { X = X + Speed },
            _               => throw new NotImplementedException()
        };

    internal Rober TurnRight()
        => Direction switch
        {
            Direction.North => new Rober(X, Y, Direction.East),
            Direction.South => new Rober(X, Y, Direction.West),
            Direction.East  => new Rober(X, Y, Direction.South),
            Direction.West  => new Rober(X, Y, Direction.North),
            _               => throw new NotImplementedException()
        };

    internal Rober TurnLeft()
        => Direction switch
        {
            Direction.North => new Rober(X, Y, Direction.West),
            Direction.South => new Rober(X, Y, Direction.East),
            Direction.East  => new Rober(X, Y, Direction.North),
            Direction.West  => new Rober(X, Y, Direction.South),
            _               => throw new NotImplementedException()
        };
}