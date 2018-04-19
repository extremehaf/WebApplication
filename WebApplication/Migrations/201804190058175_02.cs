namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RECURSO", "foto", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RECURSO", "foto", c => c.Binary());
        }
    }
}
