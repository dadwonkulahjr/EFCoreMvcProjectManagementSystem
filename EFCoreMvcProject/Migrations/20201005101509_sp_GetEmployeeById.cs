using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMvcProject.Migrations
{
    public partial class sp_GetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure sp_GetEmployeeById
                                    @Id int
                                    as
                                    Begin
	                                    Select * From Employees
	                                    Where Id = @Id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure sp_GetEmployeeById";
            migrationBuilder.Sql(procedure);
        }
    }
}
