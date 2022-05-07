using PremierLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Endpoint.InputModel
{
    public class PlayerInputModel
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public int Value { get; set; }
        public string TeamName { get; set; }

    }
}
