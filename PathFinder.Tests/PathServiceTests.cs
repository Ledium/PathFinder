using PathFinder.DataAccess;
using PathFinder.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PathFinder.Tests
{
    public class TagInsightServiceTests
    {
        private readonly PathController _pathController;


        [Fact]
        public void GetList_ShouldGetDataFromFile()
        {
            var actual = _pathController.GetList();

            Assert.NotNull(actual);
        }
    }
}
