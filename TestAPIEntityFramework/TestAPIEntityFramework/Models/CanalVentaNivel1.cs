namespace TestAPIEntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CanalVentaNivel1
    {
        [Key]
        [StringLength(10)]
        public string CV1_Id { get; set; }

        [Required]
        [StringLength(64)]
        public string CV1_Descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string CV1_Estado { get; set; }
    }
}
