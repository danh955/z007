// <copyright file="WeatherForecast.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace Core.Model
{
    using System;

    /// <summary>
    /// WeatherFforecast class.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets temperature in Celsius.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets temperature in Fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets summary.
        /// </summary>
        public string Summary { get; set; }
    }
}