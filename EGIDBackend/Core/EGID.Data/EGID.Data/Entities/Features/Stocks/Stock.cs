﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGID.Data.Entities
{
    public class Stock : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
