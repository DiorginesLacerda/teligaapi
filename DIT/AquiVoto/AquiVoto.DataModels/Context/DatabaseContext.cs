namespace AquiVoto.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Post>()
        //        .Property(e => e.Titulo)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Post>()
        //        .Property(e => e.Descricao)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Post>()
        //        .Property(e => e.Local)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Status_Post>()
        //        .Property(e => e.Descricao_Status)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Tipo_Cadastro>()
        //        .Property(e => e.Descricao_Tipo)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Nome)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Nome_Social)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Estado)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Cidade)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Email)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Usuario>()
        //        .Property(e => e.Senha)
        //        .IsUnicode(false);
        //}
    }
}
