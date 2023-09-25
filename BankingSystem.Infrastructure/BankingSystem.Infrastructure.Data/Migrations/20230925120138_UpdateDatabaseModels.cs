using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_clients_client_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_currencies_currency_id",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "currency_id",
                table: "accounts",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "accounts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_currency_id",
                table: "accounts",
                newName: "IX_accounts_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_client_id",
                table: "accounts",
                newName: "IX_accounts_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "currencies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "currencies",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "accounts",
                type: "numeric(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,2)",
                oldPrecision: 14,
                oldScale: 2)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "accounts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "accounts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateIndex(
                name: "IX_employees_email",
                table: "employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_first_name_last_name",
                table: "employees",
                columns: new[] { "first_name", "last_name" });

            migrationBuilder.CreateIndex(
                name: "IX_employees_phone_number",
                table: "employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_currencies_code",
                table: "currencies",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_email",
                table: "clients",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_first_name_last_name",
                table: "clients",
                columns: new[] { "first_name", "last_name" });

            migrationBuilder.CreateIndex(
                name: "IX_clients_phone_number",
                table: "clients",
                column: "phone_number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_clients_ClientId",
                table: "accounts",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "client_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_currencies_CurrencyId",
                table: "accounts",
                column: "CurrencyId",
                principalTable: "currencies",
                principalColumn: "currency_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_clients_ClientId",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_currencies_CurrencyId",
                table: "accounts");

            migrationBuilder.DropIndex(
                name: "IX_employees_email",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_first_name_last_name",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_phone_number",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_currencies_code",
                table: "currencies");

            migrationBuilder.DropIndex(
                name: "IX_clients_email",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_first_name_last_name",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_phone_number",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "accounts",
                newName: "currency_id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "accounts",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_CurrencyId",
                table: "accounts",
                newName: "IX_accounts_currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_ClientId",
                table: "accounts",
                newName: "IX_accounts_client_id");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "employees",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "employees",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "currencies",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "currencies",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "clients",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "clients",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "clients",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "accounts",
                type: "numeric(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,2)",
                oldPrecision: 14,
                oldScale: 2)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "currency_id",
                table: "accounts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "client_id",
                table: "accounts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_clients_client_id",
                table: "accounts",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "client_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_currencies_currency_id",
                table: "accounts",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "currency_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
