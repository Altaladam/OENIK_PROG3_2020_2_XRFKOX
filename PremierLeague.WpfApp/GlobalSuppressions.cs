// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = ".", Scope = "member", Target = "~F:PremierLeague.WpfApp.MainWindow.VM")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.MainWindow.VM")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.BL.PlayerLogic.EditorService")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.BL.PlayerLogic.EditorService")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.BL.PlayerLogic.MessengerService")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.BL.PlayerLogic.MessengerService")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = ".", Scope = "member", Target = "~M:PremierLeague.WpfApp.BL.PlayerLogic.AddPlayer(System.Collections.Generic.IList{PremierLeague.WpfApp.Data.Player})")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Is not null.", Scope = "member", Target = "~M:PremierLeague.WpfApp.BL.PlayerLogic.DelPlayer(System.Collections.Generic.IList{PremierLeague.WpfApp.Data.Player},PremierLeague.WpfApp.Data.Player)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = ".", Scope = "member", Target = "~M:PremierLeague.WpfApp.BL.PlayerLogic.GetAllPlayers~System.Collections.Generic.IList{PremierLeague.WpfApp.Data.Player}")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = ".", Scope = "member", Target = "~M:PremierLeague.WpfApp.BL.PlayerLogic.ModPlayer(PremierLeague.WpfApp.Data.Player)")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.UI.EditorWindow.VM")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Can not be private because it needs to be visible outside the class.", Scope = "member", Target = "~F:PremierLeague.WpfApp.UI.EditorWindow.VM")]
[assembly: SuppressMessage("", "CA1014", Justification ="<NikGitStats>", Scope = "module")]
