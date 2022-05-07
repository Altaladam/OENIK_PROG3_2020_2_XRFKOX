// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Models
{
    /// <summary>
    /// Auto generated VM for the errors.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the id of the request.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the RequestId is null or empty, or not.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
