using DucksOnThePond.Core.Models;
using System.Collections.Generic;

namespace DucksOnThePond.Core.Interfaces
{
    public interface IPlayerService
    {
        IList<Player> GetAllPlayers();
    }
}
