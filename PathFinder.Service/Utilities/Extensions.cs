using PathFinder.DataAccess.Entities;
using PathFinder.Service.Models;

namespace PathFinder.Service.Utilities
{
    public static class Extensions
    {
        public static PathEntity ToEntity(this PathDto dto, int[] array)
        {
            return new PathEntity
            {
                Id = dto.Id,
                Value = array,
                Path = dto.Path,
                Moves = dto.Moves
            };
        }
    }
}
