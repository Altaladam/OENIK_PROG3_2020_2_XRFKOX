// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "It needs to be able to be set for the tests.", Scope = "member", Target = "~P:PremierLeague.Data.Team.Manager")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "It needs to be able to be set for the tests.", Scope = "member", Target = "~P:PremierLeague.Data.Team.Players")]
[assembly: SuppressMessage("", "CA1014", Justification ="<NikGitStats>", Scope = "module")]