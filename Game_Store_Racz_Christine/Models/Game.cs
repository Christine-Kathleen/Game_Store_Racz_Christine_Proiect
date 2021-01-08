using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Store_Racz_Christine.Models
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryID { get; set; }

    }
}
