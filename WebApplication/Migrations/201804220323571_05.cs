namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ITEM_PERFIL", "dias_uso", c => c.Int(nullable: false));
            DropColumn("dbo.ITEM_PERFIL", "senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ITEM_PERFIL", "senha", c => c.Int(nullable: false));
            DropColumn("dbo.ITEM_PERFIL", "dias_uso");
        }
    }
}
