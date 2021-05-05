namespace TestAPIEntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseTestContext : DbContext
    {
        public BaseTestContext()
            : base("name=BaseTestContext")
        {
        }

        public virtual DbSet<CanalVentaNivel1> CanalVentaNivel1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanalVentaNivel1>()
                .Property(e => e.CV1_Id)
                .IsUnicode(false);

            modelBuilder.Entity<CanalVentaNivel1>()
                .Property(e => e.CV1_Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<CanalVentaNivel1>()
                .Property(e => e.CV1_Estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
