﻿using System.Web.Http;
using System.Web.Http.Cors;
using PlanetaryMotion.Domain.Contract;
using PlanetaryMotion.Model.Dto;

namespace PlanetaryMotion.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class StatsController : ApiController
    {
        /// <summary>
        /// The weather condition service
        /// </summary>
        private readonly IWeatherHistoryService _weatherHistoryService;
        /// <summary>
        /// Gets the stats.
        /// </summary>
        /// <returns></returns>
        [Route("stats")]
        public StatsDto GetStats()
        {
            return _weatherHistoryService.GetStats();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatsController"/> class.
        /// </summary>
        /// <param name="weatherHistoryService">The weather history service.</param>
        public StatsController(IWeatherHistoryService weatherHistoryService)
        {
            _weatherHistoryService = weatherHistoryService;
        }
    }
}
