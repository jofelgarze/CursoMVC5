namespace escuela.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSP_Notas : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
               "dbo.ingresarNotaPorIdentificacion",
               p => new
               {
                   identificacion = p.String(maxLength: 15),
                   tipo_identificacion = p.String(maxLength: 10),
                   nota1 = p.Decimal(4,2),
                   nota2 = p.Decimal(4,2)
               },
               body:
                   @"SET NOCOUNT ON;
	                IF NOT EXISTS(SELECT 1 FROM [dbo].[NotasCurso] WHERE [Identificacion] = @identificacion AND [TipoIdentificacion] = @tipo_identificacion)
	                BEGIN
		                INSERT INTO [dbo].[NotasCurso]
			                   ([Identificacion]
			                   ,[TipoIdentificacion]
			                   ,[Nota1]
			                   ,[Nota2])
		                 VALUES
			                   (@identificacion
			                   ,@tipo_identificacion
			                   ,@nota1
			                   ,@nota2)
	                END 
	                ELSE 
	                BEGIN
		                UPDATE [dbo].[NotasCurso]
		                   SET 
			                  [Nota1] = @nota1
			                  ,[Nota2] = @nota2
		                 WHERE [Identificacion] = @identificacion
			                   AND [TipoIdentificacion] = @tipo_identificacion
	                END "
           );

            CreateStoredProcedure(
               "dbo.consultaCursosAprobadosPorIdentificacion",
               p => new
               {
                   identificacion = p.String(maxLength: 15),
                   tipo_identificacion = p.String(maxLength: 10)
               },
               body:
                   @"SET NOCOUNT ON;

	            SELECT [Identificacion]
			            ,[TipoIdentificacion]
			            ,[Nota1]
			            ,[Nota2]
	            FROM [dbo].[NotasCurso]
	            WHERE [Identificacion] = @identificacion
			        AND [TipoIdentificacion] = @tipo_identificacion"
           );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.ingresarNotaPorIdentificacion");
            DropStoredProcedure("dbo.consultaCursosAprobadosPorIdentificacion");
        }
    }
}
