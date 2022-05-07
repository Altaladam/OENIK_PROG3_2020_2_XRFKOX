// <copyright file="ToStringAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Data
{
    using System;

    /// <summary>
    /// The value of the property that has this attribute will be present in the toString method.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property)]
    public sealed class ToStringAttribute : Attribute
    {
    }
}
