using System;
using System.Collections.Generic;

namespace Snake;

public class GameState
{
    public int Rows { get; }
    public int Cols { get; }
    public GridValue[,] Grid { get; }
    public Direction Dir { get; private set; }
    public int Score { get; private set; }
    public bool GameOver { get; private set; }

    private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
    private readonly Random random = new Random();

    public GameState(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Grid = new GridValue[rows,cols];
        Dir = Direction.Right;

        AddSnake();
        AddFood();
    }

    private void AddSnake()
    {
        int row = Rows / 2;

        for (int col = 1; col <= 3; col++)
        {
            Grid[row, col] = GridValue.Snake;
            snakePositions.AddFirst(new Position(row, col));
        }
    }

    private IEnumerable<Position> EmptyPositions()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                if (Grid[row,col] == GridValue.Empty)
                {
                    yield return new Position(row, col);
                }
            }
        }
    }

    private void AddFood()
    {
        List<Position> empty = new List<Position>(EmptyPositions());

        if (empty.Count == 0)
        {
            return;
        }

        Position pos = empty[random.Next(empty.Count)];
        Grid[pos.Row, pos.Col] = GridValue.Food;
    }

    public Position HeadPosition()
    {
        return snakePositions.First.Value;
    }

    public Position TailPosition()
    {
        return snakePositions.Last.Value;
    }

    public IEnumerable<Position> SnakePositions()
    {
        return snakePositions;
    }

    private void AddHead(Position pos)
    {

    }

}
