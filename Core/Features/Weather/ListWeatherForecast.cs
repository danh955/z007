// <copyright file="ListWeatherForecast.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

#pragma warning disable CA1034 // Nested types should not be visible

namespace Core.Features.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Model;
    using MediatR;

    /// <summary>
    /// Get a list of weather forecast by start date class.
    /// </summary>
    public static class ListWeatherForecast
    {
        //// Waiting for StyleCop to catch up.
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly

        /// <summary>
        /// Request.
        /// </summary>
        /// <param name="StartDate">Start date of forecast.</param>
        public record Request(DateTime StartDate) : IRequest<Result>;

        /// <summary>
        /// Result.
        /// </summary>
        /// <param name="Forecasts">List of forecasts.</param>
        public record Result(IEnumerable<Result.Forecast> Forecasts)
        {
            /// <summary>
            /// Forecast result.
            /// </summary>
            /// <param name="Date">Date of forecasts.</param>
            /// <param name="TemperatureC">Temperature in Celsius.</param>
            /// <param name="Summary">Summary.</param>
            public record Forecast(DateTime Date, int TemperatureC, string Summary)
            {
                /// <summary>
                /// Gets temperature in Fahrenheit.
                /// </summary>
                public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);
            }
        }

#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter

        /// <summary>
        /// Handler.
        /// </summary>
        public class Handler : IRequestHandler<Request, Result>
        {
            private static readonly string[] Summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
            };

            private readonly CoreDbContext context;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="context">Core database context.</param>
            public Handler(CoreDbContext context)
            {
                this.context = context;
            }

            /// <summary>
            /// Handle class.
            /// </summary>
            /// <param name="request">Query.</param>
            /// <param name="cancellationToken">CancellationToken.</param>
            /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var rng = new Random();
                var forecasts = await Task.FromResult(Enumerable.Range(1, 5)
                    .Select(index => new Result.Forecast(
                        Date: request.StartDate.AddDays(index),
                        TemperatureC: rng.Next(-20, 55),
                        Summary: Summaries[rng.Next(Summaries.Length)]))).ConfigureAwait(false);

                return new Result(forecasts);
            }
        }
    }
}