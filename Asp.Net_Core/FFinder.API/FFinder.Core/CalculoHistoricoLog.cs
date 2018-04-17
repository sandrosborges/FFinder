using System;
using System.ComponentModel.DataAnnotations;

namespace FFinder.Core
{
    public class CalculoHistoricoLog
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CoordinatexIN { get; set; }

        [Required]
        public int CoordinateyIN { get; set; }

        [Required]
        public int IdFriend { get; set; }

        [Required]
        public string FriendName { get; set; }

        [Required]
        public double FriendsDistance { get; set; }

    }
}
