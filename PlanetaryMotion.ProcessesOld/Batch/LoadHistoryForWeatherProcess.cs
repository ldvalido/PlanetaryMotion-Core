using PlanetaryMotion.Domain.Contract;
using PlanetaryMotion.Model.Model;
using PlanetaryMotion.Storage.Implementation;

namespace PlanetaryMotion.Processes.Batch
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Processes.Batch.IProcessBase" />
    public class LoadHistoryForWeatherProcess : IProcessBase
    {
        #region Public Properties        
        /// <summary>
        /// Gets or sets the weather history storage.
        /// </summary>
        /// <value>
        /// The weather history storage.
        /// </value>
        public WeatherHistoryStorage WeatherHistoryStorage { get; set; }
        /// <summary>
        /// Gets or sets the galaxy service.
        /// </summary>
        /// <value>
        /// The galaxy service.
        /// </value>
        public IGalaxyService GalaxyService { get; set; }

        /// <summary>
        /// Gets or sets the planet storage.
        /// </summary>
        /// <value>
        /// The planet storage.
        /// </value>
        public PlanetStorage PlanetStorage { get; set; }

        #endregion
        #region Overrides of ProcessBase                
        /// <summary>
        /// Executes the specified option.
        /// </summary>
        /// <param name="idExecution">The option.</param>
        public void Execute(int idExecution)
        {
            var planets = PlanetStorage.GetByCriteria(p => p.Galaxy.Id == GalaxyService.DefaultGalaxyId());
            var predictionResult = GalaxyService.PredictWeather(planets, day: idExecution);
            var weatherHistory = new WeatherHistory { Day = idExecution, Weather = predictionResult.WeatherCondition,TrianglePerimeter = predictionResult.TrianglePerimeter};
            WeatherHistoryStorage.Save(weatherHistory);
        }

        /// <summary>
        /// Determines whether [has unique execution].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has unique execution]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasUniqueExecution() => false;

        /// <summary>
        /// Executions the key.
        /// </summary>
        /// <returns></returns>
        public string ExecutionKey() => "InitialLoading";

        #endregion
    }
}
