using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverKata
{
    [TestClass]
    public class MarsRoverSpec
    {
        [TestMethod]
        public void When_robot_is_deployed_starting_location_is_x0_y0()
            => Assert.AreEqual(Robot.From(Coordinates.Default()), Robot.New());

        [TestMethod]
        public void When_robot_steps_once_location_is_x0_y1()
            => Assert.AreEqual(Robot.From(Coordinates.From(0, 1)), Robot.New().Step());

        [TestMethod]
        public void When_robot_steps_twice_location_is_x0_y2()
            => Assert.AreEqual(Robot.From(Coordinates.From(0, 2)), Robot.New().Step().Step());

        [TestMethod]
        public void When_robot_is_deployed_to_random_location_is_x5_y4()
            => Assert.AreEqual(Robot.From(Coordinates.From(5, 4)), Robot.StartsAt(5, 4));

        [TestMethod]
        public void When_robot_is_takes_5_steps_location_is_x2_y7()
            => Assert.AreEqual(Robot.From(Coordinates.From(2, 7)), Robot.StartsAt(2, 2).Step(5));

        [TestMethod]
        public void When_robot_orients_east_and_takes_1_step_location_is_x1_y0()
            => Assert.AreEqual(Robot.From(Coordinates.From(1, 0)), Robot.New().OrientEast().Step());

        [TestMethod]
        public void When_robot_walks_around_in_a_square_formation_it_returns_back_its_starting_position()
            => Assert.AreEqual(Robot.From(Coordinates.From(10, 10)), Robot
                .StartsAt(10, 10)
                .OrientEast()
                .Step(5)
                .OrientSouth()
                .Step(5)
                .OrientWest()
                .Step(5)
                .OrientNorth()
                .Step(5));

        [TestMethod]
        public void When_robot_turns_right_and_steps_its_location_is_x5_y0()
            => Assert.AreEqual(Robot.From(Coordinates.From(5, 0)), Robot
                .StartsAt(0, 0)
                .TurnRight()
                .Step(5));

        [TestMethod]
        public void When_robot_turns_left_and_steps_its_location_is_xMinus5_y0()
            => Assert.AreEqual(Robot.From(Coordinates.From(-5, 0)), Robot
                .StartsAt(0, 0)
                .TurnLeft()
                .Step(5));
    }



    public class Robot
    {
        public static class Direction
        {
            public const string North = "North";
            public const string East = "East";
            public const string South = "South";
            public const string West = "West";
        }

        private readonly Coordinates _coordinates;
        private readonly string _direction;

        private readonly Dictionary<string, Func<int, Coordinates, Coordinates>> _directionLookup = new Dictionary<string, Func<int, Coordinates, Coordinates>>
        {
            { Direction.North, (steps, coordinates) => coordinates.MoveAlongY(steps) },
            { Direction.East, (steps, coordinates) => coordinates.MoveAlongX(steps) },
            { Direction.South, (steps, coordinates) => coordinates.MoveAlongY(-steps) },
            { Direction.West, (steps, coordinates) => coordinates.MoveAlongX(-steps) }
        };

        private readonly Dictionary<string, Tuple<string, string>> _turnLookup = new Dictionary<string, Tuple<string, string>>
        {
            { Direction.North, new Tuple<string, string>(Direction.West, Direction.East)},
            { Direction.East, new Tuple<string, string>(Direction.North, Direction.South)},
            { Direction.South, new Tuple<string, string>(Direction.East, Direction.West)},
            { Direction.West, new Tuple<string, string>(Direction.South, Direction.North)},
        };

        private Robot(Coordinates coordinates, string direction = Direction.North)
        {
            _coordinates = coordinates;
            _direction = direction;
        }

        public static Robot From(Coordinates coordinates) => new Robot(coordinates);

        public static Robot New() => new Robot(Coordinates.Default());

        public static Robot StartsAt(int x, int y) => new Robot(Coordinates.From(x, y));

        public Robot Step(int count = 1) => new Robot(_directionLookup[_direction].Invoke(count, _coordinates));

        public Robot OrientNorth() => new Robot(_coordinates);

        public Robot OrientEast() => new Robot(_coordinates, Direction.East);

        public Robot OrientSouth() => new Robot(_coordinates, Direction.South);

        public Robot OrientWest() => new Robot(_coordinates, Direction.West);

        public Robot TurnRight() => new Robot(_coordinates, _turnLookup[_direction].Item2);

        public Robot TurnLeft() => new Robot(_coordinates, _turnLookup[_direction].Item1);

        public override string ToString() => $"Current position is: {_coordinates}";

        public override bool Equals(object obj) => obj != null && ((Robot)obj)._coordinates.Equals(_coordinates);

        public override int GetHashCode() => _coordinates != null ? _coordinates.GetHashCode() : 0;
    }

    public class Coordinates
    {
        private readonly int _x;
        private readonly int _y;

        private Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static Coordinates Default() => new Coordinates(0, 0);

        public static Coordinates From(int x, int y) => new Coordinates(x, y);

        public Coordinates MoveAlongX(int steps) => From(_x + steps, _y);

        public Coordinates MoveAlongY(int steps) => From(_x, _y + steps);

        public override string ToString() => $"({_x}, {_y})";

        public override bool Equals(object obj)
            => obj != null && ((Coordinates)obj)._x == _x && ((Coordinates)obj)._y == _y;

        public override int GetHashCode() => _x.GetHashCode() ^ _y.GetHashCode();
    }
}
