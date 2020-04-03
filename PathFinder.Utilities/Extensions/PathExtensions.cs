

namespace System
{
    public static class PathExtensions
    {
        public static PathDto ToDto(this PathCreateRequest request)
        {
            return new PathDto
            {
                Value = request.Input
            };
        }

        public static PathEntity ToEntity(this PathDto dto)
        {
            return new PathEntity
            {
                Id = dto.Id,
                Value = dto.Value,
                Path = dto.Path,
                Moves = dto.Moves
            };
        }
    }
}
