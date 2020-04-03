using PathFinder.DataAccess;
using PathFinder.DataAccess.Entities;
using System;
using PathFinder.Service.Models;
using PathFinder.Service.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder.Service.PathFinderService
{
    public class PathFinderService : IPathFinderService
    {

        private readonly IPathRepository _pathRepository;

        public PathFinderService(IPathRepository pathRepository)
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

          var entity = _pathRepository.Create(entry.ToEntity(array));

            return entity;
        }      
    }
}
