namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocentes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        profesorId = c.String(maxLength: 128),
                        cursoId = c.Int(nullable: false),
                        grupoId = c.Int(nullable: false),
                        numCreditosAsignados = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.cursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.grupoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.profesorId)
                .Index(t => t.profesorId)
                .Index(t => t.cursoId)
                .Index(t => t.grupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "profesorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "grupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "cursoId", "dbo.Cursos");
            DropIndex("dbo.AsignacionDocentes", new[] { "grupoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "cursoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "profesorId" });
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
