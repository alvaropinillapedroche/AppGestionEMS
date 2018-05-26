namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cursoId = c.Int(nullable: false),
                        alumnoId = c.String(maxLength: 128),
                        convocatoria = c.Int(nullable: false),
                        notaP1 = c.Single(nullable: false),
                        notaP2 = c.Single(nullable: false),
                        notaP3 = c.Single(nullable: false),
                        notaP4 = c.Single(nullable: false),
                        notaPractica = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.alumnoId)
                .ForeignKey("dbo.Cursos", t => t.cursoId, cascadeDelete: true)
                .Index(t => t.cursoId)
                .Index(t => t.alumnoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluaciones", "cursoId", "dbo.Cursos");
            DropForeignKey("dbo.Evaluaciones", "alumnoId", "dbo.AspNetUsers");
            DropIndex("dbo.Evaluaciones", new[] { "alumnoId" });
            DropIndex("dbo.Evaluaciones", new[] { "cursoId" });
            DropTable("dbo.Evaluaciones");
        }
    }
}
