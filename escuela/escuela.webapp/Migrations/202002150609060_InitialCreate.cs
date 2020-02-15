namespace escuela.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        MateriaId = c.Int(nullable: false),
                        Profesor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materia", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.Profesor_Id)
                .Index(t => t.MateriaId)
                .Index(t => t.Profesor_Id);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        Identificacion = c.String(nullable: false, maxLength: 128),
                        TipoIdentificacion = c.Int(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 150, unicode: false),
                        Apellidos = c.String(nullable: false, maxLength: 150, unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identificacion);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 150),
                        Apellidos = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EstudianteCurso",
                c => new
                    {
                        Estudiante_Identificacion = c.String(nullable: false, maxLength: 128),
                        Curso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Estudiante_Identificacion, t.Curso_Id })
                .ForeignKey("dbo.Estudiante", t => t.Estudiante_Identificacion, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.Curso_Id, cascadeDelete: true)
                .Index(t => t.Estudiante_Identificacion)
                .Index(t => t.Curso_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Curso", "Profesor_Id", "dbo.Profesor");
            DropForeignKey("dbo.Curso", "MateriaId", "dbo.Materia");
            DropForeignKey("dbo.EstudianteCurso", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.EstudianteCurso", "Estudiante_Identificacion", "dbo.Estudiante");
            DropIndex("dbo.EstudianteCurso", new[] { "Curso_Id" });
            DropIndex("dbo.EstudianteCurso", new[] { "Estudiante_Identificacion" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Curso", new[] { "Profesor_Id" });
            DropIndex("dbo.Curso", new[] { "MateriaId" });
            DropTable("dbo.EstudianteCurso");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profesor");
            DropTable("dbo.Materia");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Curso");
        }
    }
}
