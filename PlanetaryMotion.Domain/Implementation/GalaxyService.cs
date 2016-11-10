﻿using System.Collections.Generic;
using System.Linq;
using PlanetaryMotion.Domain.Contract;
using PlanetaryMotion.Geometry;
using PlanetaryMotion.Model;
using PlanetaryMotion.Model.Model;
using PlanetaryMotion.Storage.Implementation;

namespace PlanetaryMotion.Domain.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Domain.Contract.IGalaxyService" />
    public class GalaxyService : IGalaxyService
    {
        /// <summary>
        /// Gets or sets the planet movement service.
        /// </summary>
        /// <value>
        /// The planet movement service.
        /// </value>
        public IPlanetMovementService PlanetMovementService { get; set; }

        #region Implementation of IGalaxyService        

        /// <summary>
        /// Predicts the weather.
        /// </summary>
        /// <param name="planets">The planets.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public WeatherCondition PredictWeather(IEnumerable<Planet> planets, int day)
        {
            var lstPoints = new List<Point>();

            foreach (var planet in planets)
            {
                var startPoint = new Point(0,planet.Radious);
                var finalPoint = PlanetMovementService.Calculate(startPoint, planet.Angle, day);
                lstPoints.Add(finalPoint);
            }
            
            if (lstPoints.First().AreAligned(lstPoints.Skip(1)))
            {
                var rect = new Rect(lstPoints.First(), lstPoints.Last());
                return rect.Belongs(new Point(0, 0)) ? WeatherCondition.Drought : WeatherCondition.STP;
            }
            else
            {
                var triangle = new Triangle(lstPoints[0],lstPoints[1],lstPoints[2]);
                return triangle.Belongs(new Point(0, 0)) ? WeatherCondition.Rainy : WeatherCondition.Unknown;
            }
        }

        /// <summary>
        /// Gets or sets the default galaxy identifier.
        /// </summary>
        /// <value>
        /// The default galaxy identifier.
        /// </value>
        public int DefaultGalaxyId() => 1;

        #endregion
    }
}
