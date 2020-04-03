using System.Collections.Generic;

namespace PathFinder.DataAccess.Entities
{
    public class PathEntity
    {
        public int Id { get; set; }
        public int[] Value { get; set; }
        public IEnumerable<int> Path { get; set; }
        public int Moves { get; set; }
    }
}
