using PathFinder.DataAccess.Entities;
using System.Collections.Generic;

namespace PathFinder.Service.PathFinderService
{
    public interface IPathService
    {
        public IEnumerable<PathEntity> GetList();
        public PathEntity Get(int id);
        public PathEntity Create(int[] array);
    }
}
