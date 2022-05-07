// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "-", Scope = "member", Target = "~M:PremierLeague.Web.Controllers.PlayersController.#ctor(PremierLeague.Logic.IModifyLogic,PremierLeague.Logic.IReadLogic,AutoMapper.IMapper)")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "-", Scope = "member", Target = "~P:PremierLeague.Web.Models.PlayerListViewModel.Players")]
[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "It's not read only.", Scope = "member", Target = "~P:PremierLeague.Web.Models.PlayerListViewModel.Players")]
