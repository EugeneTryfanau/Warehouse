﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Department
    {
        [Column("DepartmentId")]
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Product>? Products { get; set; }

        public ICollection<Worker>? Workers { get; set; }
    }
}
