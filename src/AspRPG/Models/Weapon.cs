using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace AspRPG.Models
{
    [Table("Weapons")]
    public class Weapon
    {

        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int DmgMod { get; set; }
        public int? MonsterId { get; set; }
        public virtual Monster Monster { get; set; }
        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public Weapon() { }

        public Weapon(int monsterId, string description, int dmgMod)
        {
            MonsterId = monsterId;
            Description = description;
            DmgMod = dmgMod;
        }
    }
}
