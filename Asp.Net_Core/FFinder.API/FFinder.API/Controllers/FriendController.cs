using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FFinder.Core;
using FFinder.Infra;


namespace FFinder.API.Controllers
{ 
    
    [Produces("application/json")]
    [Route("api/Friend")]
    public class FriendController : Controller
    {
        // GET api/Friend
        [HttpGet]
        public IEnumerable<Friend> Get()
        {
            Core.Friend friendCore = new Core.Friend(new Infra.FriendRepository());
            return friendCore.GetAllFriends();
        }

        [HttpGet("{id}")]
        public Friend Get(int id)
        {
            Core.Friend friendCore = new Core.Friend(new Infra.FriendRepository());
            return friendCore.Get(id);
        }

        [HttpGet("NEAR/{id}")]
        public IEnumerable<Friend> GetFriendsNear(int id)
        {
            Core.Friend friendCore = new Core.Friend(new Infra.FriendRepository());
            return friendCore.GetFriendsNear(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            Core.Friend friendCore = new Core.Friend(new Infra.FriendRepository());
            friendCore.Remove(id);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Friend friend)
        {
            Core.Friend friendCore = new Core.Friend(new Infra.FriendRepository());
            friendCore.Add(friend);

        }
    }
}