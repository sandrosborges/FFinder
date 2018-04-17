using System;
using System.Collections.Generic;
using System.Text;
using FFinder.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FFinder.Infra
{
    public class FriendRepository : Core.Interfaces.IFriendRepository, IDisposable
    {
        public FriendContext context;

        public FriendRepository()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            this.context = new FriendContext();
        }

        public void Add(Friend friend)
        {
            context.Friend.Add(friend);
            context.SaveChanges();
        }

        public void AddLog(CalculoHistoricoLog CalculoLog)
        {
            context.CalculoHistoricoLog.Add(CalculoLog);
            context.SaveChanges();
        }



        public void Edit(Friend friend)
        {
            context.Entry(friend).State = EntityState.Modified;
        }

        public Friend FindById(int Id)
        {
            var friend = (from f in context.Friend where f.Id == Id select f).FirstOrDefault();
            return friend;
        }

        public IEnumerable<Friend> GetAllFriends()
        {
            return context.Friend;
        }

    
        public void Remove(int FriendID)
        {
            Friend f = context.Friend.Find(FriendID);
            context.Friend.Remove(f);
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~FriendRepository()
        {
            this.Dispose();     
        }
    }
}
