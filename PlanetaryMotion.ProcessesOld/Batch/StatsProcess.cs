using System;
using PlanetaryMotion.Domain.Contract;

namespace PlanetaryMotion.Processes.Batch
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Processes.Batch.IProcessBase" />
    public class StatsProcess : IProcessBase
    {
        /// <summary>
        /// Gets or sets the weather history service.
        /// </summary>
        /// <value>
        /// The weather history service.
        /// </value>
        public IWeatherHistoryService WeatherHistoryService { get; set; }

        #region Implementation of IProcessBase

        /// <summary>
        /// Executes the specified option.
        /// </summary>
        /// <param name="idExecution">The option.</param>
        public void Execute(int idExecution)
        {
            var result = WeatherHistoryService.GetStats();
            Console.WriteLine($"Periodos Sequias: {result.DroughtPeriods}");
            Console.WriteLine($"Periodos Lluviosos: {result.RainyPeriods}");
            Console.WriteLine($"Periodos con condiciones normales de presión y temperatura: {result.StpPeriods}");
            Console.WriteLine($"Otros Periodos: {result.UnknownPeriods}");
            Console.WriteLine($"Perimetro Máximo del triangulo: {result.MaxTrianglePerimter}");
        }

        /// <summary>
        /// Determines whether [has unique execution].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has unique execution]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasUniqueExecution() => true;

        /// <summary>
        /// Executions the key.
        /// </summary>
        /// <returns></returns>
        public string ExecutionKey() => "Stats";

        #endregion
    }
}
