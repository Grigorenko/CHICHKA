using Model.Context;
using Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CHICHKA.Controllers
{
    public class GameController : ApiController
    {
        ChichkaContext db;
        public GameController()
        {
            db = new ChichkaContext();
        }
        public ICollection<Game> Get()
        {
            return db.Games.ToList();
        }

        public void Add(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
        }
    }
}
