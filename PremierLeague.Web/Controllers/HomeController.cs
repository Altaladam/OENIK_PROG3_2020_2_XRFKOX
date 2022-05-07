// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PremierLeague.Web.Models;

    /// <summary>
    /// Auto generated Home Controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Auto generated logger.
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">A logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Index action.
        /// </summary>
        /// <returns>Returns an action interface.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Privacy action.
        /// </summary>
        /// <returns>Returns an action interface.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Error action.
        /// </summary>
        /// <returns>Returns an action interface.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
