using PathFinder.DataAccess.Entities;
using System.Collections.Generic;

namespace PathFinder.DataAccess
{
    public interface IPathRepository
    {
        public IEnumerable<PathEntity> GetList();

        public PathEntity Get(int id);

        public PathEntity Create(PathEntity entity);
    }
}
