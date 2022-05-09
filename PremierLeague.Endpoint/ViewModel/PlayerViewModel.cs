using PremierLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Endpoint.ViewModel
{
    public class PlayerViewModel
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public int Value { get; set; }
        public string Team { get; set; }

        public static PlayerViewModel Convert(Player p)
        {
            return new PlayerViewModel() {
                PlayerID = p.PlayerID,
                Name = p.Name,
                Nationality = p.Nationality,
                Birthday = p.Birthday,
                Position = p.Position,
                Value = p.Value,
                Team = p.Team.Name
            };
        }

    }
}
