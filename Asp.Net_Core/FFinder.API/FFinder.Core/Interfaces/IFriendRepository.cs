using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.Core.Interfaces
{
    public interface IFriendRepository
    {
        void Add(Friend friend);
        void Edit(Friend friend);
        void Remove(int FriendID);
        IEnumerable<Friend> GetAllFriends();
        Friend FindById(int Id);
        void AddLog(CalculoHistoricoLog CalculoLog);
        
    }
}
