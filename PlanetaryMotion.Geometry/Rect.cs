using System;
using PlanetaryMotion.Geometry.Extension;
using PlanetaryMotion.Geometry.RectBelong;

namespace PlanetaryMotion.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public class Rect
    {
        #region Private Properties
        private readonly Point _vertex1;
        private readonly Point _vertex2;
        private readonly IBelongRect _belongChecker;

        #endregion
        #region C...tor        
        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class.
        /// </summary>
        /// <param name="vertex1">The vertex1.</param>
        /// <param name="vertex2">The vertex2.</param>
        public Rect(Point vertex1, Point vertex2)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            //(y-y1) / (y2-y1) = (x-x1) / (x2-x1)
            var divisor = vertex2.X - vertex1.X;
            if (!divisor.IsSimilar(0))
            {
                var b = (vertex1.Y*vertex2.X - vertex1.X*vertex2.Y)/divisor;
                var m = (vertex2.Y - vertex1.Y)/(divisor);
                _belongChecker = new StandardRect(m,b); 
            }
            else
            {
                _belongChecker = new ParallelRect(vertex1.X);
            }
        }
        #endregion
        #region Public Method        
        /// <summary>
        /// Belongses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public bool Belongs(Point point)
        {
            return _belongChecker.Belongs(point);
        }
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(_vertex1.X-_vertex2.X,2) + Math.Pow(_vertex1.Y - _vertex2.Y,2));
        }
        #endregion
    }
}
