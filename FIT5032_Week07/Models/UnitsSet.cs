namespace FIT5032_Week07.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnitsSet")]
    public partial class UnitsSet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int StudentsId { get; set; }

        public virtual StudentsSet StudentsSet { get; set; }
    }
}
