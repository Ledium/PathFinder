using PathFinder.Service.Utilities;
using Xunit;

namespace PathFinderTest
{
    public class PathFinderTests
    {

        [Theory]
        [InlineData(new int[3] { 1, 0, 1 })]
        [InlineData(new int[3] { 0, 2, 3 })]
        [InlineData(new int[3] { 0, 0, 0 })]
        [InlineData(new int[7] { 1, 2, 0, 1, 0, 2, 0 })]
        [InlineData(new int[7] { 1, 2, 0, -1, 0, 2, 0 })]
        [InlineData(new int[7] { 1, 2, 1, -1, 0, 2, 0 })]
        public void CalculateMove_ShouldReturnNull(int[] arr)
        {
            var result = PathUtilities.CalculateMoves(arr, arr.Length);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(new int[7] { 1, 2, 0, 3, 0, 2, 0 })]
        [InlineData(new int[7] { 1, 2, 6, 0, 0, 0, 0 })]
        [InlineData(new int[7] { 1, 2, 6, 0, 2, 0, 0 })]
        public void CalculateMove_ShouldReturnAnArray(int[] arr)
        {
            var result = PathUtilities.CalculateMoves(arr, arr.Length);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(new int[3] { 1, 0, 1 })]
        [InlineData(new int[3] { 0, 2, 3 })]
        [InlineData(new int[3] { 0, 0, 0 })]
        public void FindPath_ShouldReturnNull(int[] arr)
        {
            var result = PathUtilities.FindPath(arr);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(new int[7] { 1, 2, 0, 3, 0, 2, 0 })]
        [InlineData(new int[7] { 1, 2, 6, 0, 0, 0, 0 })]
        [InlineData(new int[7] { 1, 2, 6, 0, 2, 0, 0 })]
        public void FindPath_ShouldReturnAnObjectWithProperties(int[] arr)
        {
            var result = PathUtilities.FindPath(arr);

            Assert.NotNull(result.Path);
            Assert.Equal(3, result.Moves);
        }
    }
}
