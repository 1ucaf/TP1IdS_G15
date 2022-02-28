namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesConvention : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Sesions", newName: "Sesiones");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sesiones", newName: "Sesions");
        }
    }
}
