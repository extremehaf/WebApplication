namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PERFIL_CONSUMO", "Descricao", c => c.String(unicode: false));
            AddColumn("dbo.PERFIL_CONSUMO", "Adicional", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PERFIL_CONSUMO", "Adicional");
            DropColumn("dbo.PERFIL_CONSUMO", "Descricao");
        }
    }
}
