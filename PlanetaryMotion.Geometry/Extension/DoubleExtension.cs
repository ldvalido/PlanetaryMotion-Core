using System;

namespace PlanetaryMotion.Geometry.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Determines whether the specified another double is multiple.
        /// </summary>
        /// <param name="aDouble">a double.</param>
        /// <param name="anotherDouble">Another double.</param>
        /// <returns>
        ///   <c>true</c> if the specified another double is multiple; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMultiple(this double aDouble, double anotherDouble)
        {
            return (aDouble%anotherDouble).IsSimilar(0);
        }

        /// <summary>
        /// Ares the similar.
        /// </summary>
        /// <param name="aDouble">a double.</param>
        /// <param name="anotherDouble">Another double.</param>
        /// <returns></returns>
        public static bool IsSimilar(this double aDouble, double anotherDouble)
        {
            return Math.Round(aDouble - anotherDouble, GeometryConst.CriteriaRound) == 0;
        }
    }
}
