namespace PlanetaryMotion.Geometry.RectBelong
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IBelongRect
    {
        /// <summary>
        /// Belongses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        bool Belongs(Point point);
    }
}
