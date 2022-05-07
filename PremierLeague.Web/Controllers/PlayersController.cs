// <copyright file="PlayersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PremierLeague.Logic;
    using PremierLeague.Web.Models;

    /// <summary>
    /// A controller for the players.
    /// </summary>
    public class PlayersController : Controller
    {
        /// <summary>
        /// An instance of the IModifyLogic interface.
        /// </summary>
        private readonly IModifyLogic modifyLogic;

        /// <summary>
        /// An instance of the IReadLogic interface.
        /// </summary>
        private readonly IReadLogic readLogic;

        /// <summary>
        /// An instance of the mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// An instance of the viewmodel.
        /// </summary>
        private readonly PlayerListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersController"/> class.
        /// </summary>
        /// <param name="modifyLogic">An instance of the IModifyLogic interface.</param>
        /// <param name="readLogic">An instance of the IReadLogic interface.</param>
        /// <param name="mapper">An instance of the IMapper interface.</param>
        public PlayersController(IModifyLogic modifyLogic, IReadLogic readLogic, IMapper mapper)
        {
            this.modifyLogic = modifyLogic;
            this.readLogic = readLogic;
            this.mapper = mapper;

            this.vm = new PlayerListViewModel();
            this.vm.EditedPlayer = new Models.Player();

            var players = readLogic.GetAllPlayers();
            this.vm.Players = mapper.Map<IList<Data.Player>, List<Models.Player>>(players);
        }

        /// <summary>
        /// Index Action.
        /// </summary>
        /// <returns>An action interface.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("PlayersIndex", this.vm);
        }

        /// <summary>
        /// An action for getting the detailed view of one player.
        /// </summary>
        /// <param name="id">The id of the player.</param>
        /// <returns>An action interface.</returns>
        public IActionResult Details(int id)
        {
            return this.View("PlayersDetails", this.GetPlayerModel(id));
        }

        /// <summary>
        /// An action for deleting a player.
        /// </summary>
        /// <param name="id">The id of the player.</param>
        /// <returns>An action interface.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Törlés SIKERES";
            this.modifyLogic.DeletePlayer(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// An action for editing a player.
        /// </summary>
        /// <param name="id">The id of the player.</param>
        /// <returns>An action interface.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedPlayer = this.GetPlayerModel(id);
            return this.View("PlayersIndex", this.vm);
        }

        /// <summary>
        /// An action for editing or adding a player.
        /// </summary>
        /// <param name="player">The player to be added or the player that has been edited.</param>
        /// <param name="editAction">A string that decides if the player is being added or edited.</param>
        /// <returns>An action interface.</returns>
        [HttpPost]
        public IActionResult Edit(Models.Player player, string editAction)
        {
            if (this.ModelState.IsValid && player != null)
            {
                this.TempData["editResult"] = "Módosítás SIKERES";
                if (editAction == "AddNew")
                {
                    Data.Player temp = new Data.Player();
                    temp.Name = player.Name;
                    temp.Nationality = player.Nationality;
                    temp.Position = player.Position;
                    temp.Value = player.Value;
                    temp.Birthday = player.Birthday;
                    temp.Team = this.readLogic.GetTeamByID(1);
                    temp.TeamID = this.readLogic.GetTeamByID(1).TeamID;
                    this.modifyLogic.AddPlayer(temp);
                }
                else
                {
                    int id = player.Id;
                    this.modifyLogic.ChangePlayerBirthday(id, player.Birthday);
                    this.modifyLogic.ChangePlayerName(id, player.Name);
                    this.modifyLogic.ChangePlayerNationality(id, player.Nationality);
                    this.modifyLogic.ChangePlayerPosition(id, player.Position);
                    this.modifyLogic.ChangePlayerValue(id, player.Value);
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedPlayer = player;
                return this.View("PlayersIndex", this.vm);
            }
        }

        private Models.Player GetPlayerModel(int id)
        {
            Data.Player onePlayer = this.readLogic.GetPlayerByID(id);
            return this.mapper.Map<Data.Player, Models.Player>(onePlayer);
        }
    }
}
