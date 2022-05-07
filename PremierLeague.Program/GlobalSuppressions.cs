// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The object shouldn't be disposed of.", Scope = "member", Target = "~M:PremierLeague.Program.Factory.GetTeamRepository~PremierLeague.Repository.TeamRepository")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The object shouldn't be disposed of.", Scope = "member", Target = "~M:PremierLeague.Program.Factory.GetPlayerRepository~PremierLeague.Repository.PlayerRepository")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The object shouldn't be disposed of.", Scope = "member", Target = "~M:PremierLeague.Program.Factory.GetManagerRepository~PremierLeague.Repository.ManagerRepository")]
[assembly: SuppressMessage("", "CA1014", Justification ="<NikGitStats>", Scope = "module")]