using System;

namespace PlanetaryMotion.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle
    {

        #region Public Properties        
        /// <summary>
        /// Gets or sets the vertex1.
        /// </summary>
        /// <value>
        /// The vertex1.
        /// </value>
        public Point Vertex1 { get; set; }
        /// <summary>
        /// Gets or sets the vertex2.
        /// </summary>
        /// <value>
        /// The vertex2.
        /// </value>
        public Point Vertex2 { get; set; }
        /// <summary>
        /// Gets or sets the vertex3.
        /// </summary>
        /// <value>
        /// The vertex3.
        /// </value>
        public Point Vertex3 { get; set; }
        #endregion

        #region C...tor        
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="vertex1">The vertex1.</param>
        /// <param name="vertex2">The vertex2.</param>
        /// <param name="vertex3">The vertex3.</param>
        /// <exception cref="ArgumentException">The points are aligned and the triangle cannot be built</exception>
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            if (!vertex1.AreAligned(vertex2,vertex3))
            {
                Vertex1 = vertex1;
                Vertex2 = vertex2;
                Vertex3 = vertex3;
            }
            else
            {
                throw new ArgumentException("The points are aligned and the triangle cannot be built");
            }
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            var r1 = new Rect(Vertex1,Vertex2);
            var r2 = new Rect(Vertex1,Vertex3);
            var r3 = new Rect(Vertex2,Vertex3);
            var returnValue =  r1.GetLength() + r2.GetLength() + r3.GetLength();
            return returnValue;
        }
        /// <summary>
        /// Belongses to triangle.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public bool Belongs(Point point)
        {
            var orientation1 = Orientation(point,Vertex1,Vertex2) < 0f;
            var orientation2 = Orientation(point, Vertex2, Vertex3) < 0f;
            var orientation3 = Orientation(point, Vertex3, Vertex1) < 0f;

            return ((orientation1 == orientation2) && (orientation2 == orientation3));
        }
        #endregion

        #region Auxiliar Methods
        /// <summary>
        /// Orientations the specified vertex1.
        /// </summary>
        /// <param name="vertex1">The vertex1.</param>
        /// <param name="vertex2">The vertex2.</param>
        /// <param name="vertex3">The vertex3.</param>
        /// <returns></returns>
        double Orientation(Point vertex1, Point vertex2,Point vertex3)
        {
            return (vertex1.X - vertex3.X) * (vertex2.Y - vertex3.Y) - (vertex2.X - vertex3.X) * (vertex1.Y - vertex3.Y);
        }
        #endregion

    }
}