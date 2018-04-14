namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RECURSO", name: "data_nascimento", newName: "voltagem");
            AlterColumn("dbo.PERFIL_CONSUMO", "tipo", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            AlterColumn("dbo.RECURSO", "descricao", c => c.String(maxLength: 250, storeType: "nvarchar"));
            AlterColumn("dbo.RECURSO", "foto", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RECURSO", "foto", c => c.Binary(nullable: false));
            AlterColumn("dbo.RECURSO", "descricao", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            AlterColumn("dbo.PERFIL_CONSUMO", "tipo", c => c.String(unicode: false));
            RenameColumn(table: "dbo.RECURSO", name: "voltagem", newName: "data_nascimento");
        }
    }
}
