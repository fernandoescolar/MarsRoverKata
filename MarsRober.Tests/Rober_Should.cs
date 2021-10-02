using Xunit;

namespace MarsRober.Tests;

public class Rober_Should
{
    [Fact]
    public void Have_An_Initial_Starting_Point()
    {
        var target = new Rober(1, 1, Direction.North);

        Assert.Equal(1, target.X);
        Assert.Equal(1, target.Y);
    }

    [Fact]
    public void Have_An_Initial_Starting_Direction()
    {
        var target = new Rober(1, 1, Direction.North);

        Assert.Equal(Direction.North, target.Direction);
    }

    [Theory]
    [InlineData(Direction.North, 1, 1, 1, 2)]
    [InlineData(Direction.South, 1, 1, 1, 0)]
    [InlineData(Direction.East, 1, 1, 2, 1)]
    [InlineData(Direction.West, 1, 1, 0, 1)]
    public void Move_Forward(Direction currentDirection, int currentX, int currentY, int expectedX, int expectedY)
    {
        var target = new Rober(currentX, currentY, currentDirection);

        var actual = target.MoveForward();

        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }

    [Theory]
    [InlineData(Direction.North, 1, 1, 1, 0)]
    [InlineData(Direction.South, 1, 1, 1, 2)]
    [InlineData(Direction.East, 1, 1, 0, 1)]
    [InlineData(Direction.West, 1, 1, 2, 1)]
    public void Move_Backward(Direction currentDirection, int currentX, int currentY, int expectedX, int expectedY)
    {
        var target = new Rober(currentX, currentY, currentDirection);

        var actual = target.MoveBackward();

        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
    }

    [Theory]
    [InlineData(Direction.North, 1, 1, Direction.East)]
    [InlineData(Direction.South, 1, 1, Direction.West)]
    [InlineData(Direction.East, 1, 1, Direction.South)]
    [InlineData(Direction.West, 1, 1, Direction.North)]
    public void Turn_Right(Direction currentDirection, int currentX, int currentY, Direction expectedDirection)
    {
        var target = new Rober(currentX, currentY, currentDirection);

        var actual = target.TurnRight();

        Assert.Equal(expectedDirection, actual.Direction);
    }

    [Theory]
    [InlineData(Direction.North, 1, 1, Direction.West)]
    [InlineData(Direction.South, 1, 1, Direction.East)]
    [InlineData(Direction.East, 1, 1, Direction.North)]
    [InlineData(Direction.West, 1, 1, Direction.South)]
    public void Turn_Left(Direction currentDirection, int currentX, int currentY, Direction expectedDirection)
    {
        var target = new Rober(currentX, currentY, currentDirection);

        var actual = target.TurnLeft();

        Assert.Equal(expectedDirection, actual.Direction);
    }

    // test the rober movement when it receives a command
    [Theory]
    [InlineData("RFRFRFRF", 1, 1, Direction.North)]
    //[InlineData("FRRFLLFFRRFLL", 3, 3, Direction.West)]
    //[InlineData("LLFFFLFLFL", 3, 3, Direction.North)]
    [InlineData("FFFFFFFF", 1, 9, Direction.North)]
    public void Move_Forward_When_Receive_Command(string command, int expectedX, int expectedY, Direction expectedDirection)
    {
        var target = new Rober(1, 1, Direction.North);

        var actual = target.Execute(command);

        Assert.Equal(expectedX, actual.X);
        Assert.Equal(expectedY, actual.Y);
        Assert.Equal(expectedDirection, actual.Direction);
    }
}
