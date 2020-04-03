using PathFinder.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder.Service.Utilities
{
    public static class PathUtilities
    {
        public static int[] CalculateMoves(int[] arr, int n)
        {
            int[] moves = new int[n];
            if (n == 0 || arr[0] == 0)
                return null;

            moves[0] = 0;

            for (int i = 1; i < n; i++)
            {
                moves[i] = int.MaxValue;

                for (int j = 0; j < i; j++)
                {
                    if (i <= j + arr[j] && moves[j] != int.MaxValue)
                    {
                        moves[i] = Math.Min(moves[i], moves[j] + 1);
                        break;
                    }
                }
            }

            if (moves[n - 1].Equals(int.MaxValue))
            {
                return null;
            }
            else
            {
                return moves;
            }
        }

        public static PathDto FindPath(int[] arr)
        {
            int n = arr.Length;

            var moves = CalculateMoves(arr, n);

            if (moves == null)
                return null;

            var moveCount = moves.ToList();

            var indexes = new List<int>();

            var path = new List<int>();

            moveCount.RemoveAt(0);

            for (int i = 0; i < moveCount.Count; i++)
            {
                if (i < moveCount.Count - 1 && moveCount[i] != moveCount[i + 1])
                {
                    if (moveCount[i] == 1)
                    {
                        indexes.Add(i);
                        indexes.Add(i + 1);
                    }
                    else
                    {
                        indexes.Add(i + 1);
                    }
                }
            }

            foreach (var index in indexes)
            {
                path.Add(arr[index]);
            }

            path.Add(arr[arr.Length - 1]);

            var result = new PathDto
            {
                Moves = moveCount[moveCount.Count - 1],
                Path = path
            };

            return result;
        }
    }
}
