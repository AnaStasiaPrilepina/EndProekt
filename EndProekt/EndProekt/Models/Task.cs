using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EndProekt.Models
{
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Who { get; set; }
        public string Status { get; set; }
    }
}
