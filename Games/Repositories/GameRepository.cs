using Games.DATA;
using Games.Entity;
using Games.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Repositories
{
    public class GameRepository : RepositoryBase<GameEntity>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {

        }
    }
}
