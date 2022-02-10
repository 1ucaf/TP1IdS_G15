namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Productoes", "Rubro_Id", "dbo.Rubroes");
            DropIndex("dbo.Productoes", new[] { "Marca_Id" });
            DropIndex("dbo.Productoes", new[] { "Rubro_Id" });
            DropColumn("dbo.Productoes", "MarcaId");
            DropColumn("dbo.Productoes", "RubroId");
            RenameColumn(table: "dbo.Productoes", name: "Marca_Id", newName: "MarcaId");
            RenameColumn(table: "dbo.Productoes", name: "Rubro_Id", newName: "RubroId");
            DropPrimaryKey("dbo.Marcas");
            DropPrimaryKey("dbo.Rubroes");
            AlterColumn("dbo.Marcas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Productoes", "MarcaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "RubroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rubroes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Marcas", "Id");
            AddPrimaryKey("dbo.Rubroes", "Id");
            CreateIndex("dbo.Productoes", "MarcaId");
            CreateIndex("dbo.Productoes", "RubroId");
            AddForeignKey("dbo.Productoes", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Productoes", "RubroId", "dbo.Rubroes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "RubroId", "dbo.Rubroes");
            DropForeignKey("dbo.Productoes", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Productoes", new[] { "RubroId" });
            DropIndex("dbo.Productoes", new[] { "MarcaId" });
            DropPrimaryKey("dbo.Rubroes");
            DropPrimaryKey("dbo.Marcas");
            AlterColumn("dbo.Rubroes", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Productoes", "RubroId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Productoes", "MarcaId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Marcas", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Rubroes", "Id");
            AddPrimaryKey("dbo.Marcas", "Id");
            RenameColumn(table: "dbo.Productoes", name: "RubroId", newName: "Rubro_Id");
            RenameColumn(table: "dbo.Productoes", name: "MarcaId", newName: "Marca_Id");
            AddColumn("dbo.Productoes", "RubroId", c => c.Int(nullable: false));
            AddColumn("dbo.Productoes", "MarcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Productoes", "Rubro_Id");
            CreateIndex("dbo.Productoes", "Marca_Id");
            AddForeignKey("dbo.Productoes", "Rubro_Id", "dbo.Rubroes", "Id");
            AddForeignKey("dbo.Productoes", "Marca_Id", "dbo.Marcas", "Id");
        }
    }
}
