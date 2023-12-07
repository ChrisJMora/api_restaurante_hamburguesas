using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_restaurante_hamburguesas.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telefono_cliente",
                table: "Clientes",
                type: "varchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 1,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 57, 40, 437, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 2,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 57, 40, 437, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 1,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3782), new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3772), "AQAAAAIAAYagAAAAEJpMyId+3d28n5UJtxoB+k4TXBfqyNC6kvApuJ7TUE+bhUzihBaih0V5+oesvmr6rw==", "41EE35701EBAFCC29534BDE021B32C6B59DCF605518FF285F8B198D95CBA41F989E7C74913D4B7C71C6320FB0B409E292AEC24A80B5486AA3D8C202D5FFABAD3" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 2,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3788), new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3787), "AQAAAAIAAYagAAAAEFdRaVakpVSureEsbz9oiTIvaNLRPdafxi9Lv7Oa3dMYi0gEEA1N6n7d4bSCLuD8ew==", "7DEDCF052FE762424891F13925CF557ED30DB5F7FE65C6B42EFFD343410B95B7563D71CB507E3C3747026DE6C577D944C7B0704F777F71B8E3E7CF259C751E58" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 3,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3790), new DateTime(2023, 12, 6, 16, 57, 40, 292, DateTimeKind.Local).AddTicks(3790), "AQAAAAIAAYagAAAAEKyqcqjwxegIwghjN+1FtF0kZ+2UrQNLJampPGGPoudzaKolG9RhdA8i/h2y/rDewQ==", "3AA975EFD8E28975488397E4818B11CA5844CB1DF6490E2589F71AC2E93D9404786D48B2F159A9AA4EACA5E71C83E4AB5DA9C6E848248876858EB4AE3759EE25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telefono_cliente",
                table: "Clientes",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)");

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 1,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 9, 47, 907, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 2,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 9, 47, 907, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 1,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4372), new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4360), "AQAAAAIAAYagAAAAEPKstRJYJzZyfcqmUWYIMwUybTRfzFFtyDjlR/09krTIAYmkmH+iV5I8m/5QOyWrGQ==", "2697AD1B76649885FD7C46CB9075C9C6F552FE2D16E58379DFCDB0CBC59C5E7F1D5FB414BC062564E74083C8CBF471125FE4A4D2E99317C493D87F8D8B8F0115" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 2,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4379), new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4378), "AQAAAAIAAYagAAAAEJYNmkh9BYMaruhhooHWbYQxICZmERd80M9W+oCDjk6MjJUSwRCre8iUrgug1Vfk1Q==", "706DD8EFDE04D9B9854C1F194BCA979B3D69C81834B8A24426369D34125F95B3BB60CBF4E8ADB3D1C95165852F33A04A0EAA3DFD5B132CEC084EECAC3343FFA7" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 3,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4382), new DateTime(2023, 12, 6, 16, 9, 47, 710, DateTimeKind.Local).AddTicks(4381), "AQAAAAIAAYagAAAAEJImFgeWLnVp/f7gqijnrSZL2hQF/fiE7DFz7N4I9X1nWKaPE5qXyMdjo2yyIy9oAw==", "401EE0A9D0BA0E61DB6DF729935B552C65464B68BE9B8B47E64DCA608783AC4F9D7DC8AF0851505BB0178FBBDFB4B6FD8C3B08ACDA0DAF9816D2D58E802FAEE8" });
        }
    }
}
