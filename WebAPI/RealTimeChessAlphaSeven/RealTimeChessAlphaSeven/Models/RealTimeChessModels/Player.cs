using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int AuthenticationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumWins { get; set; }
        public int NumLosses { get; set; }
        public Boolean IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; }

        public Player() {  }

    }


}
