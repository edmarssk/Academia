namespace Academia.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Mae", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Mae");
        }
    }
}
