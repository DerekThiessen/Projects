using DucksOnThePond.Core.Models;
using System.Collections.Generic;

namespace DucksOnThePond.Models
{
    public class RosterViewModel
    {
        public virtual IList<Player> Players { get; set; }
    }
}