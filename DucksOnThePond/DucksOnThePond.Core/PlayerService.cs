using DucksOnThePond.Core.Interfaces;
using DucksOnThePond.Core.Models;
using DucksOnThePond.Dal.Interfaces;
using DucksOnThePond.Dal.Repositorys;
using System.Collections.Generic;

namespace DucksOnThePond.Core
{
    public class PlayerService : IPlayerService
    {
        private IRepository<Player> _repository;

        public PlayerService()
        {
            _repository = new PlayerRepository<Player>();
        }

        public IList<Player> GetAllPlayers()
        {
            return _repository.GetAll();
        }

    }
}