using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PremierLeague.Data;
using PremierLeague.Endpoint.InputModel;
using PremierLeague.Endpoint.Services;
using PremierLeague.Endpoint.ViewModel;
using PremierLeague.Logic;
using PremierLeague.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IReadLogic readLogic;
        IModifyLogic modifyLogic;
        IHubContext<SignalRHub> hub;

        public PlayerController(IReadLogic readLogic, IModifyLogic modifyLogic, IHubContext<SignalRHub> hub)
        {
            this.readLogic = readLogic;
            this.modifyLogic = modifyLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<PlayerViewModel> ReadAll()
        {
            return this.readLogic.GetAllPlayers().Select(PlayerViewModel.Convert);
        }

        [HttpGet("{id}")]
        public PlayerViewModel Read(int id)
        {
            return PlayerViewModel.Convert(this.readLogic.GetPlayerByID(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlayerInputModel value)
        {
            try
            {
                Player p = new Player()
                {
                    Name = value.Name,
                    Nationality = value.Nationality,
                    Position = value.Position,
                    Birthday = value.Birthday,
                    Value = value.Value,
                    TeamID = readLogic.GetTeamByName(value.TeamName).TeamID
                };
                this.modifyLogic.AddPlayer(p);
                this.hub.Clients.All.SendAsync("PlayerCreated", p);
            }
            catch (InvalidOperationException)
            {

                return new NotFoundResult();
            }
            return Ok();
        }

        [HttpPut]
        public void Put([FromBody] PlayerUpdateModel value)
        {
            this.modifyLogic.ChangePlayerBirthday(value.PlayerID, value.Birthday);
            this.modifyLogic.ChangePlayerName(value.PlayerID, value.Name);
            this.modifyLogic.ChangePlayerNationality(value.PlayerID, value.Nationality);
            this.modifyLogic.ChangePlayerPosition(value.PlayerID, value.Position);
            this.modifyLogic.ChangePlayerValue(value.PlayerID, value.Value);
            if (readLogic.GetAllTeams().Contains(readLogic.GetTeamByName(value.TeamName)))
            {
                this.modifyLogic.ChangePlayerTeam(value.PlayerID, readLogic.GetTeamByName(value.TeamName).TeamID);
            }
            this.hub.Clients.All.SendAsync("PlayerUpdated", readLogic.GetPlayerByID(value.PlayerID));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var playerToDelete = this.readLogic.GetPlayerByID(id);
            this.modifyLogic.DeletePlayer(id);
            this.hub.Clients.All.SendAsync("PlayerDeleted", playerToDelete);
        }
    }
}
