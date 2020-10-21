// <copyright file="WeatherPage.razor.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace BlazorUI.Features.Weather
{
    using System;
    using System.Threading.Tasks;
    using BlazorUI.Data;
    using Microsoft.AspNetCore.Components;

    /// <content>
    /// Weather page class.
    /// </content>
    public partial class WeatherPage : ComponentBase
    {
        private WeatherForecast[] forecasts;

        [Inject]
        private WeatherForecastService ForecastService { get; set; }

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            this.forecasts = await this.ForecastService.GetForecastAsync(DateTime.Now).ConfigureAwait(false);
        }
    }
}