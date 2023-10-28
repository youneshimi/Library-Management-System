namespace bibliothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprunts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LivreId = c.Int(nullable: false),
                        AbonneId = c.Int(nullable: false),
                        DateEmprunt = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Auteur = c.String(),
                        Resume = c.String(),
                        EstEmprunte = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livres");
            DropTable("dbo.Emprunts");
            DropTable("dbo.Abonnes");
        }
    }
}
