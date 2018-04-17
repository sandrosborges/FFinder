using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFinder.Infra;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;


namespace FFinder.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new Infra.FriendRepository();
            var result = repo.GetAllFriends();
            Assert.IsNotNull(result);
            //var numberOfRecords = result.ToList().Count;
            //Assert.AreEqual(2, numberOfRecords);
        }

        [TestMethod]
        public void TestFriendAdd()
        {
            using (var repoFriend = new Infra.FriendRepository())
            {
                var f = new Core.Friend()
                {
                    CoordinateX = 10,
                    CoordinateY = 20,
                    Name = "Friend 1"
                };

                var qtPrevious = repoFriend.GetAllFriends().Count();

                repoFriend.Add(f);
                var qt = repoFriend.GetAllFriends().Count();

                Assert.IsTrue(qt > qtPrevious);

            }
        }


    }
}
