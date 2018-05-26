namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        alumnoId = c.String(maxLength: 128),
                        cursoId = c.Int(nullable: false),
                        grupoId = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.alumnoId)
                .ForeignKey("dbo.Cursos", t => t.cursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.grupoId, cascadeDelete: true)
                .Index(t => t.alumnoId)
                .Index(t => t.cursoId)
                .Index(t => t.grupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "grupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "cursoId", "dbo.Cursos");
            DropForeignKey("dbo.Matriculas", "alumnoId", "dbo.AspNetUsers");
            DropIndex("dbo.Matriculas", new[] { "grupoId" });
            DropIndex("dbo.Matriculas", new[] { "cursoId" });
            DropIndex("dbo.Matriculas", new[] { "alumnoId" });
            DropTable("dbo.Matriculas");
        }
    }
}
