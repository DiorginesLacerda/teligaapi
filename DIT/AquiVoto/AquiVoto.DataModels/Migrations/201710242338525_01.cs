namespace AquiVoto.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Post_Id = c.Long(nullable: false, identity: true),
                        Usuario_Id = c.Long(),
                        Guid = c.String(),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Aberto_ao_Publico = c.Short(),
                        Local = c.String(),
                        Data_Votacao = c.DateTime(),
                        Data_Criacao = c.DateTime(nullable: false),
                        Data_Alteracao = c.DateTime(nullable: false),
                        Post_Semelhante_Repetido = c.Short(nullable: false),
                        Status_Post = c.String(),
                        Observacao_Moderador = c.String(),
                    })
                .PrimaryKey(t => t.Post_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Usuario_Id = c.Long(nullable: false, identity: true),
                        Tipo_Cadastro = c.Int(nullable: false),
                        Guid = c.String(),
                        Nome = c.String(),
                        Estado = c.String(),
                        Cidade = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Data_Cadastro = c.DateTime(nullable: false),
                        Data_Alteracao = c.DateTime(nullable: false),
                        Ativo = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Post");
        }
    }
}
