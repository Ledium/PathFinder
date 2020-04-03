using PathFinder.DataAccess.Entities;
using PathFinder.DataAccess.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinder.DataAccess
{
    public class PathRepository : IPathRepository
    {
        private readonly JsonUtilities _jsonUtilities;

        public PathRepository()
        {
            _jsonUtilities = new JsonUtilities();
        }

        public IEnumerable<PathEntity> GetList()
        {
            return _jsonUtilities.GetData();
        }

        public PathEntity Get(int id)
        {
            return _jsonUtilities.GetData(id);
        }

        public PathEntity Create(PathEntity entity)
        {
            return  _jsonUtilities.InsertData(entity);
        }
    }
}
