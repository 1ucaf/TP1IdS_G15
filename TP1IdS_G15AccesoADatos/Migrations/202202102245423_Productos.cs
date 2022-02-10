namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        CodigoDeBarra = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Costo = c.Double(nullable: false),
                        MargenDeGanancia = c.Double(nullable: false),
                        PorcentajeIVA = c.Double(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        RubroId = c.Int(nullable: false),
                        Marca_Id = c.String(maxLength: 128),
                        Rubro_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CodigoDeBarra)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id)
                .ForeignKey("dbo.Rubroes", t => t.Rubro_Id)
                .Index(t => t.Marca_Id)
                .Index(t => t.Rubro_Id);
            
            CreateTable(
                "dbo.Rubroes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "TipoUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Rubro_Id", "dbo.Rubroes");
            DropForeignKey("dbo.Productoes", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Productoes", new[] { "Rubro_Id" });
            DropIndex("dbo.Productoes", new[] { "Marca_Id" });
            DropColumn("dbo.Users", "TipoUsuario");
            DropTable("dbo.Rubroes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Marcas");
        }
    }
}
