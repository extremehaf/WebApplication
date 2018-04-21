namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_diario", c => c.Double(defaultValue: 0.0));
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_mensal", c => c.Double(defaultValue: 0.0));
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_estimado", c => c.Double(defaultValue: 0.0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_estimado", c => c.Double(nullable: false));
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_mensal", c => c.Double(nullable: false));
            AlterColumn("dbo.PERFIL_CONSUMO", "consumo_diario", c => c.Double(nullable: false));
        }
    }
}
