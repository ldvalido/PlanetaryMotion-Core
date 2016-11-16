using System;
using System.Collections.Generic;
using PlanetaryMotion.Geometry.Extension;
using Xunit;

namespace PlanetaryMotion.Geometry.Test
{
    public class PointTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestAlignment()
        {
            var p1 = new Point(10, 1);
            var p2 = new Point(-10, 1);
            var p3 = new Point(-20, 1);
            var res = p1.AreAligned( new List<Point> {p2,p3} );
            Assert.True(res);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestNonAlignment()
        {
            var p1 = new Point(0, 1);
            var p2 = new Point(1, 0);
            var p3 = new Point(2, 1);
            var res = p1.AreAligned(new List<Point> { p2, p3 });
            Assert.False(res);
        }

        [Fact]
        public void TestNullMovement()
        {
            var pStart = new Point(0,0);
            var finalPoint = pStart.MoveAngle(180);
            Assert.Equal(finalPoint.X,0d);
            Assert.Equal(finalPoint.Y,0d);
        }
        /// <summary>
        /// Tests the null movement.
        /// </summary>
        [Fact]
        public void TestBasicMovement()
        {
            var pStart = new Point(1, 0);
            var finalPoint = pStart.MoveAngle(180);
            Assert.Equal(finalPoint.X, -1d);
            Assert.Equal(finalPoint.Y, 0d);
        }

        /// <summary>
        /// Tests the null movement.
        /// </summary>
        [Fact]
        public void TestCompleteCycleMovement()
        {
            var pStart = new Point(1, 0);
            var finalPoint = pStart.MoveAngle(90);
            Assert.Equal(finalPoint.X, 0d);
            Assert.Equal(finalPoint.Y, 1d);
        }

        /// <summary>
        /// Tests the null movement.
        /// </summary>
        [Fact]
        public void TestHalfCycleMovement()
        {
            var pStart = new Point(1, 0);
            var finalPoint = pStart.MoveAngle(45);
            Assert.True(finalPoint.X.IsSimilar(Math.Sqrt(2)/ 2));
            Assert.True(finalPoint.Y.IsSimilar(Math.Sqrt(2) / 2));
        }
    }
}
