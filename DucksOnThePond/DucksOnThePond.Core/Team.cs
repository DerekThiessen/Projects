using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DucksOnThePond.Core
{
    public class Team
    {
        List<Coach> Coaches { get; set; }
        List<Player> Players { get; set; }
    }
}