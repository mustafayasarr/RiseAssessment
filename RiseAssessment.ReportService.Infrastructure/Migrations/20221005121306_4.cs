using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiseAssessment.ReportService.Infrastructure.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ReportItem",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportCreateDate",
                table: "ReportItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportName",
                table: "ReportItem",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestObjectJson",
                table: "ReportItem",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ReportItem");

            migrationBuilder.DropColumn(
                name: "ReportCreateDate",
                table: "ReportItem");

            migrationBuilder.DropColumn(
                name: "ReportName",
                table: "ReportItem");

            migrationBuilder.DropColumn(
                name: "RequestObjectJson",
                table: "ReportItem");
        }
    }
}
