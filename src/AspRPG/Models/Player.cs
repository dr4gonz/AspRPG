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
        public virtual Weapon Weapon { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Hp { get; set; }
        public int DmgMod { get; set; }

        public Player() { }
        public void LevelUp()
        {
            if (Exp >= 25)
            {
                Hp = 25;
                DmgMod += 1;
                Level += 1;
            }
            if (Exp >= 50)
            {
                Hp = 35;
                DmgMod += 2;
                Level += 1;
            }

        }
    }
}
