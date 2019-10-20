namespace Academia.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Rg = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        TelefoneCelular = c.String(maxLength: 100, unicode: false),
                        DtNascimento = c.DateTime(nullable: false),
                        DtCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Mae = c.String(maxLength: 100, unicode: false),
                        PlanoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        EstadoSigla = c.String(nullable: false, maxLength: 2, unicode: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Sigla = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        PeriodoMeses = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PlanoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Enderecos", new[] { "ClienteId" });
            DropTable("dbo.Plano");
            DropTable("dbo.Estados");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Clientes");
        }
    }
}
