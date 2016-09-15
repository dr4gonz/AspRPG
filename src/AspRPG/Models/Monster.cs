using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace AspRPG.Models
{
    [Table("Monsters")]
    public class Monster
    {

        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Hp { get; set; }
        public int DmgMod { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Weapon Weapon { get; set; }
        public int Exp { get; set; }
        public Monster() { }
        public Monster(int locationId, string description)
        {
            if(description == "Dragon")
            {
                LocationId = locationId;
                Description = description;
                Hp = 100;
                DmgMod = 20;
                Exp = 1000;
            }
            else
            {
            LocationId = locationId;
            Description = description;
            Hp = 10;
            DmgMod = 1;
            Exp = 5;

            }
        }
    }
}
