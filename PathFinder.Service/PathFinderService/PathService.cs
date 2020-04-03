using PathFinder.DataAccess;
using PathFinder.DataAccess.Entities;
using PathFinder.Service.Utilities;
using System.Collections.Generic;

namespace PathFinder.Service.PathFinderService
{
    public class PathService : IPathService
    {

        private readonly IPathRepository _pathRepository;

        public PathService(IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
        }

        public IEnumerable<PathEntity> GetList()
        {
            return _pathRepository.GetList();
        }

        public PathEntity Get(int id)
        {
            return _pathRepository.Get(id);
        }

        public PathEntity Create(int[] array)
        {

           var entry = PathUtilities.FindPath(array);
           var entity = new PathEntity();

           if(entry != null)
              entity = _pathRepository.Create(entry.ToEntity(array));

            return entity;
        }      
    }
}
