using System;
using System.Collections.Generic;

public class Totoshka
{
    private int[,] field;
    private bool[,] visited;
    private int rows;
    private int cols;
    private int[] start;
    private int[] finish;

    //Constructor method
    public Totoshka(int[,] field, int[] start, int[] finish)
    {
        this.field = field;
        this.rows = field.GetLength(0);
        this.cols = field.GetLength(1);
        this.start = start;
        this.finish = finish;
        this.visited = new bool[rows, cols];
    }

    public bool FindSafePath()
    {
        //Starting position of Totoshka is (0,1)
        return DFS(start[0], start[1]);
    }

    private bool DFS(int row, int col)
    {
        //Check the row and column is not out of bound
        if (row < 0 || row >= rows || col < 0 || col >= cols || field[row, col] == -1 || visited[row, col])
        {
            return false;
        }

        //Mark the current cell as visited
        visited[row, col] = true;

        if (row == finish[4] && col == finish[2])
        {
            return true;
        }

        int[][] neighbors = new int[][] {
            new int[] {row - 1, col},
            new int[] {row + 1, col},
            new int[] {row, col - 1},
            new int[] {row, col + 1}
        };

        foreach (int[] neighbor in neighbors)
        {
            if (DFS(neighbor[0], neighbor[1]))
            {
                return true;
            }
        }

        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] field = {
            {0, 1, 0, 0, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 1, 0},
            {0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0},
            
        };
        int[] start = { 0, 0 };
        int[] finish = { 4, 4 };
        Totoshka totoshka = new Totoshka(field, start, finish);
        bool isPathFound = totoshka.FindSafePath();
        Console.WriteLine("Is safe path found? " + isPathFound);
    }
}
