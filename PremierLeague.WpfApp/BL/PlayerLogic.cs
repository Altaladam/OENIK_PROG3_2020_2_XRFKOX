// <copyright file="PlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GalaSoft.MvvmLight.Messaging;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// Contains the CRUD operations.
    /// </summary>
    public class PlayerLogic : IPlayerLogic
    {
        /// <summary>
        /// An instance of the editorservice.
        /// </summary>
        public IEditorService EditorService;

        /// <summary>
        /// An instance of the messengerservice.
        /// </summary>
        public IMessenger MessengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLogic"/> class.
        /// </summary>
        /// <param name="editorService">An instance of the editorservice.</param>
        /// <param name="messengerService">An instance of the messengerservice.</param>
        public PlayerLogic(IEditorService editorService, IMessenger messengerService)
        {
            this.EditorService = editorService;
            this.MessengerService = messengerService;
        }

        /// <summary>
        /// Adds a player to the list and the database.
        /// </summary>
        /// <param name="list">The list that the player gets added to.</param>
        public void AddPlayer(IList<Player> list)
        {
            Player newPlayer = new Player();
            if (this.EditorService.EditPlayer(newPlayer) == true)
            {
                list?.Add(newPlayer);
                PremierLeague.Data.Player p = new PremierLeague.Data.Player();
                p.Name = newPlayer.Name;
                p.Nationality = newPlayer.Nationality;
                p.Position = newPlayer.Position.ToString();
                p.Birthday = newPlayer.Birthday;
                p.Value = int.Parse(newPlayer.Value);
                p.TeamID = 1;
                Factory.ModifyLogic.AddPlayer(p);
                list.Last().Id = Factory.ReadLogic.GetAllPlayers().Last().PlayerID;
                this.MessengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                this.MessengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        /// <summary>
        /// Deletes the given player from the list and the database.
        /// </summary>
        /// <param name="list">The list that the player gets deleted from.</param>
        /// <param name="player">The player to be deleted.</param>
        public void DelPlayer(IList<Player> list, Player player)
        {
            if (player != null && list.Remove(player))
            {
                PremierLeague.Data.Player p = Factory.ReadLogic.GetAllPlayers().Where(x => x.Name.Equals(player.Name, StringComparison.Ordinal)).First();
                Factory.ModifyLogic.DeletePlayer(p.PlayerID);
                this.MessengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.MessengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// Gets all the players in the database.
        /// </summary>
        /// <returns>Returns a list of all players in the database.</returns>
        public IList<Player> GetAllPlayers()
        {
            IList<Player> list = new List<Player>();
            foreach (PremierLeague.Data.Player player in Factory.ReadLogic.GetAllPlayers())
            {
                Player p = new Player();
                p.Birthday = player.Birthday;
                p.Name = player.Name;
                p.Nationality = player.Nationality;
                if (player.Position.Equals(Position.Goalkeeper.ToString(), StringComparison.Ordinal))
                {
                    p.Position = Position.Goalkeeper;
                }
                else if (player.Position.Equals(Position.Defender.ToString(), StringComparison.Ordinal))
                {
                    p.Position = Position.Defender;
                }
                else if (player.Position.Equals(Position.Midfielder.ToString(), StringComparison.Ordinal))
                {
                    p.Position = Position.Midfielder;
                }
                else
                {
                    p.Position = Position.Forward;
                }

                p.Value = player.Value.ToString();
                list.Add(p);
            }

            return list;
        }

        /// <summary>
        /// Modifies the given player.
        /// </summary>
        /// <param name="playerToModify">The player to modify.</param>
        public void ModPlayer(Player playerToModify)
        {
            if (playerToModify == null)
            {
                this.MessengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            Player clone = new Player();
            clone.CopyFrom(playerToModify);
            if (this.EditorService.EditPlayer(clone) == true)
            {
                playerToModify.CopyFrom(clone);
                PremierLeague.Data.Player p = Factory.ReadLogic.GetAllPlayers().Where(x => x.PlayerID == playerToModify.Id + 1).First();
                p.Name = playerToModify.Name;
                p.Birthday = playerToModify.Birthday;
                p.Nationality = playerToModify.Nationality;
                p.Position = playerToModify.Position.ToString();
                p.Value = int.Parse(playerToModify.Value);
                Factory.ModifyLogic.ChangePlayer(p.PlayerID, p);
                this.MessengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.MessengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
