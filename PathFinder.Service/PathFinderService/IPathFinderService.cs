using PathFinder.DataAccess.Entities;
using PathFinder.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinder.Service.PathFinderService
{
    public interface IPathFinderService
    {
        public IEnumerable<PathEntity> GetList();
        public PathEntity Get(int id);
        public PathEntity Create(int[] array);
    }
}
