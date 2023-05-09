using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    internal class minefield
    {
        static void Main(string[] args)
        {
            char[,] minefield = new char[,] {
            {'X', '√', 'X', 'X', 'X'},
            {'X', 'X', '√', 'X', 'X'},
            {'X', 'X', 'X', '√', 'X'},
            {'X', 'X', 'X', '√', 'X'},
            {'X', 'X', '√', 'X', 'X'}
        };

            int n = minefield.GetLength(0);
            int m = minefield.GetLength(1);

            bool[,] visited = new bool[n, m];
            int[] dx = new int[] { 0, 0, 1, -1 };
            int[] dy = new int[] { 1, -1, 0, 0 };

            int startX = 0;
            int startY = 0;

            // find the starting position of Totoshka
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (minefield[i, j] == '√')
                    {
                        startX = i;
                        startY = j;
                        break;
                    }
                }
            }

            // perform DFS to find a safe path
            bool foundPath = DFS(minefield, visited, dx, dy, startX, startY);

            // print the minefield with the safe path
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (minefield[i, j] == '√' || visited[i, j])
                    {
                        Console.Write(minefield[i, j]);
                    }
                    else
                    {
                        Console.Write('X');
                    }
                }
                Console.WriteLine();
            }

            if (!foundPath)
            {
                Console.WriteLine("No safe path found!");
            }
        }

        static bool DFS(char[,] minefield, bool[,] visited, int[] dx, int[] dy, int x, int y)
        {
            int n = minefield.GetLength(0);
            int m = minefield.GetLength(1);

            visited[x, y] = true;

            if (minefield[x, y] == ' ')
            {
                return true;
            }

            for (int i = 0; i < dx.Length; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                {
                    continue;
                }

                if (visited[nx, ny] || minefield[nx, ny] == 'X')
                {
                    continue;
                }

                if (DFS(minefield, visited, dx, dy, nx, ny))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
