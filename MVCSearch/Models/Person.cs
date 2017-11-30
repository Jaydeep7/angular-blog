namespace MVCSearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person
    {
        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Age { get; set; }
    }
}
