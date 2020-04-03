using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathFinder.Presentation.Responses
{
    public class PathResponse
    {
        public int Id { get; set; }
        public int[] Value { get; set; }
        public IEnumerable<int> Path { get; set; }
        public int Moves { get; set; }
    }
}
