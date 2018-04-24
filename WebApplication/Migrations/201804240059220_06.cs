namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ITEM_PERFIL", "Tempo_uso", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ITEM_PERFIL", "Tempo_uso", c => c.Int(nullable: false));
        }
    }
}
