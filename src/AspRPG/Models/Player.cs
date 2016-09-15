using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspRPG.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CurrentRoomId { get; set; }
        public Location CurrentRoom { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int Hp { get; set; }
        public int DmgMod { get; set; }

        public Player() { }
    }
}
