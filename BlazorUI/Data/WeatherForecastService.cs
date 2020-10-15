// <copyright file="WeatherForecastService.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace BlazorUI.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Weather forecast service class.
    /// </summary>
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        /// <summary>
        /// Get forecast.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <returns>List of weather forecasts.</returns>
#pragma warning disable CA1822 // Mark members as static
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
#pragma warning restore CA1822 // Mark members as static
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            }).ToArray());
        }
    }
}