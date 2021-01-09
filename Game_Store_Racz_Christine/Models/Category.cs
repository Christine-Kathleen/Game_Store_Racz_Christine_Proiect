using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Store_Racz_Christine.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        public string CategoryName { get; set; }

        [NotNull]
        public bool IsActive { get; set; } = true;

    }
}
