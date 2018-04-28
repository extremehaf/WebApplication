namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ITEM_PERFIL",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecursoId = c.Int(nullable: false),
                        PerfilId = c.Int(nullable: false),
                        quantidade = c.Int(nullable: false),
                        dias_uso = c.Int(nullable: false),
                        Tempo_uso = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PERFIL_CONSUMO", t => t.PerfilId, cascadeDelete: true)
                .ForeignKey("dbo.RECURSO", t => t.RecursoId, cascadeDelete: true)
                .Index(t => t.RecursoId)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.PERFIL_CONSUMO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        usuario_id = c.Int(nullable: false),
                        tipo = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        icms = c.Double(nullable: false),
                        pis = c.Double(nullable: false),
                        cofins = c.Double(nullable: false),
                        Adicional = c.Double(nullable: false),
                        kwh = c.Double(nullable: false),
                        consumo_diario = c.Double(),
                        consumo_mensal = c.Double(),
                        consumo_estimado = c.Double(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.USUARIO", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        email = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        senha = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        endereco = c.String(maxLength: 250, storeType: "nvarchar"),
                        data_nascimento = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RECURSO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(maxLength: 250, storeType: "nvarchar"),
                        usuario_id = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        foto = c.String(unicode: false),
                        voltagem = c.String(nullable: false, unicode: false),
                        potencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.USUARIO", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RECURSO", "usuario_id", "dbo.USUARIO");
            DropForeignKey("dbo.ITEM_PERFIL", "RecursoId", "dbo.RECURSO");
            DropForeignKey("dbo.PERFIL_CONSUMO", "usuario_id", "dbo.USUARIO");
            DropForeignKey("dbo.ITEM_PERFIL", "PerfilId", "dbo.PERFIL_CONSUMO");
            DropIndex("dbo.RECURSO", new[] { "usuario_id" });
            DropIndex("dbo.PERFIL_CONSUMO", new[] { "usuario_id" });
            DropIndex("dbo.ITEM_PERFIL", new[] { "PerfilId" });
            DropIndex("dbo.ITEM_PERFIL", new[] { "RecursoId" });
            DropTable("dbo.RECURSO");
            DropTable("dbo.USUARIO");
            DropTable("dbo.PERFIL_CONSUMO");
            DropTable("dbo.ITEM_PERFIL");
        }
    }
}
