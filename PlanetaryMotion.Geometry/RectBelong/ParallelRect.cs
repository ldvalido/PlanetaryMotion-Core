using System;
using PlanetaryMotion.Geometry.Extension;

namespace PlanetaryMotion.Geometry.RectBelong
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Geometry.RectBelong.IBelongRect" />
    internal class ParallelRect : IBelongRect
    {
        #region Private Properties

        private readonly double _c;
        #endregion

        #region C...tor

        public ParallelRect(double c)
        {
            _c = c;
        }
        #endregion

        #region Implementation of IBelongRect

        /// <summary>
        /// Belongses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public bool Belongs(Point point)
        {
            return point.X.IsSimilar(_c);
        }

        #endregion
    }
}
