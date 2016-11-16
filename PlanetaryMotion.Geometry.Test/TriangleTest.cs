using System;
using Xunit;

namespace PlanetaryMotion.Geometry.Test
{
    public class TriangleTest
    {
        [Fact]
        public void TestBasicTriangle()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.NotNull(triangle);
        }

        [Fact]
        public void TestValidationTriangleCreationOnY()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(new Point(0, 0), new Point(10, 0), new Point(5, 0)));
        }



        [Fact]
        public void TestValidationTriangleCreationOnX()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(new Point(0, 0), new Point(0, 10), new Point(0, 5)));
        }

        [Fact]
        public void TestPointBelongTotriangle()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.NotNull(triangle);
            var resultBelongs = triangle.Belongs(new Point(1, 1));
            Assert.True(resultBelongs);
        }


        [Fact]
        public void TestPointDoesnotBelongTotriangle()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.NotNull(triangle);
            var resultBelongs = triangle.Belongs(new Point(-1, -1));
            Assert.False(resultBelongs);
        }
    }
}
