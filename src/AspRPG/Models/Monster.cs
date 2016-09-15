﻿using System;
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
        private StringValues stringValues;

        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Hp { get; set; }
        public int DmgMod { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Monster() { }
        public Monster(int locationId, string description)
        {
            LocationId = locationId;
            Description = description;
            Hp = 10;
            DmgMod = 1;
        }
    }
}