namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ITEM_PERFIL", "PerfilId", "dbo.PERFIL_CONSUMO");
            DropForeignKey("dbo.ITEM_PERFIL", "RecursoId", "dbo.RECURSO");
            DropForeignKey("dbo.PERFIL_CONSUMO", "usuario_id", "dbo.USUARIO");
            DropForeignKey("dbo.RECURSO", "usuario_id", "dbo.USUARIO");
            AddForeignKey("dbo.ITEM_PERFIL", "PerfilId", "dbo.PERFIL_CONSUMO", "id", cascadeDelete: true);
            AddForeignKey("dbo.ITEM_PERFIL", "RecursoId", "dbo.RECURSO", "id", cascadeDelete: true);
            AddForeignKey("dbo.PERFIL_CONSUMO", "usuario_id", "dbo.USUARIO", "id", cascadeDelete: true);
            AddForeignKey("dbo.RECURSO", "usuario_id", "dbo.USUARIO", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RECURSO", "usuario_id", "dbo.USUARIO");
            DropForeignKey("dbo.PERFIL_CONSUMO", "usuario_id", "dbo.USUARIO");
            DropForeignKey("dbo.ITEM_PERFIL", "RecursoId", "dbo.RECURSO");
            DropForeignKey("dbo.ITEM_PERFIL", "PerfilId", "dbo.PERFIL_CONSUMO");
            AddForeignKey("dbo.RECURSO", "usuario_id", "dbo.USUARIO", "id");
            AddForeignKey("dbo.PERFIL_CONSUMO", "usuario_id", "dbo.USUARIO", "id");
            AddForeignKey("dbo.ITEM_PERFIL", "RecursoId", "dbo.RECURSO", "id");
            AddForeignKey("dbo.ITEM_PERFIL", "PerfilId", "dbo.PERFIL_CONSUMO", "id");
        }
    }
}
