using System;
using PlanetaryMotion.Geometry.Extension;

namespace PlanetaryMotion.Geometry.RectBelong
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Geometry.RectBelong.IBelongRect" />
    internal class StandardRect : IBelongRect
    {
        #region Private Properties

        private readonly double _m;
        readonly double _b;
        #endregion
        #region C...tor        
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardRect"/> class.
        /// </summary>
        public StandardRect(double m, double b)
        {
            _b = b;
            _m = m;
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
            return point.Y.IsSimilar(point.X * _m + _b);
        }

        #endregion
    }
}
