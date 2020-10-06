using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMvcProject.Migrations
{
    public partial class sp_InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure sp_InsertData
                                @FullName nvarchar(50),
                                @OfficeEmail nvarchar(50),
                                @Photo nvarchar(50),
                                @Department nvarchar(50),
                                @Salary decimal(18,2)
                                as
                                Begin
	                                Insert Into Employees(FullName, [Office Email],
	                                Photo, Department, Salary)
	                                Values(@FullName, @OfficeEmail, @Photo, @Department, @Salary)	
                                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop Procedure sp_InsertData";
            migrationBuilder.Sql(procedure);
        }
    }
    
}
