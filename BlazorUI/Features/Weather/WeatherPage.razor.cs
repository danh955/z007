// <copyright file="WeatherPage.razor.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace BlazorUI.Features.Weather
{
    using System;
    using System.Threading.Tasks;
    using Core.Features.Weather;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    /// <content>
    /// Weather page class.
    /// </content>
    public partial class WeatherPage : ComponentBase
    {
        private ListWeatherForecast.Result model;

        [Inject]
        private IMediator Mediator { get; set; }

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            this.model = await this.Mediator.Send(new ListWeatherForecast.Request(DateTime.Now)).ConfigureAwait(false);
        }
    }
}