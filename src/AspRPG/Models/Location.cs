using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspRPG.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasRoom { get; set; }
        public bool WestDoor { get; set; }
        public bool EastDoor { get; set; }
        public bool NorthDoor { get; set; }
        public bool SouthDoor { get; set; }
        public bool IsOccupied { get; set; }
        public bool Visited { get; set; }
        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        public Location() { }
        public Location(int mapId, int x, int y)
        {
            MapId = mapId;
            X = x;
            Y = y;
            IsOccupied = false;
            HasRoom = false;
        }
    }
}
