using Xunit;

namespace PlanetaryMotion.Geometry.Test
{
    public class RectTest
    {
        [Fact]
        public void BasicRect()
        {
            var rect = new Rect(new Point(1,2),new Point(2,4) );
            Assert.NotNull(rect);
        }
        [Fact]
        public void BelongtoRect()
        {
            var rect = new Rect(new Point(1, 2), new Point(2, 4));
            Assert.NotNull(rect);
            var res = rect.Belongs(new Point(3, 6));
            Assert.True(res);
        }
    }
}
