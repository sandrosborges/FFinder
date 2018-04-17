using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FFinder.Infra;


namespace FFinder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new FFinder.Infra.FriendRepository();
            var context = repo.context;

            
        }
    }
}
