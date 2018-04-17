using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace FFinder.Core
{
    public class Friend
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        private Interfaces.IFriendRepository _repo;

        public Friend()
        {
        }

        public Friend(Interfaces.IFriendRepository repo)
        {
            this._repo = repo;
        }

        public IEnumerable<Friend> GetAllFriends()
        {
            return this._repo.GetAllFriends();
        }

        public IEnumerable<Friend> GetFriendsNear(int id)        
        {
            var srcFriend = this.Get(id);

            var ret = (from f in this._repo.GetAllFriends()
                       where f.Id != id
                       orderby (CalculaDistancia(srcFriend.CoordinateX, 
                       srcFriend.CoordinateY, 
                       f.CoordinateX, 
                       f.CoordinateY))
                       select new {
                            friend = f,
                            distancia = CalculaDistancia(srcFriend.CoordinateX, 
                            srcFriend.CoordinateY, 
                            f.CoordinateX, 
                            f.CoordinateY
                       )
                       }
                       ).Take(3);

            var hists = from h in ret
                            select new CalculoHistoricoLog{
                                Id =0,
                                CoordinatexIN = srcFriend.CoordinateX,
                                CoordinateyIN = srcFriend.CoordinateY,
                                FriendsDistance = h.distancia,
                                IdFriend = h.friend.Id,
                                FriendName = h.friend.Name
                            };

            // Add os Losgs de Calculo
            foreach(var h in hists)
                        this._repo.AddLog(h);


            return ret.Select(x=> x.friend);

        }


        private double CalculaDistancia(int srcX, int srcY, int x, int y)
        {
            return Math.Sqrt(Math.Pow(srcX - x, 2) + Math.Pow(srcY - y, 2));
        }

        public Friend Get(int id)
        {
            return this._repo.FindById(id);
        }

        public void Remove(int id)
        {
            this._repo.Remove(id);
        }

        public void Add(Friend friend)
        {
            this._repo.Add(friend);
        }


    }
}
