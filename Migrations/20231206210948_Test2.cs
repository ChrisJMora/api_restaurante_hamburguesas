using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_restaurante_hamburguesas.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 1,
                column: "telefono_cliente",
                value: "0992724743");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 2,
                column: "telefono_cliente",
                value: "0992755743");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 1,
                column: "telefono_cliente",
                value: "0992744743");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "id_cliente",
                keyValue: 2,
                column: "telefono_cliente",
                value: "0992744743");

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 1,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 8, 3, 367, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Ordenes",
                keyColumn: "id_orden",
                keyValue: 2,
                column: "fecha_compra_orden",
                value: new DateTime(2023, 12, 6, 16, 8, 3, 367, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 1,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4670), new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4659), "AQAAAAIAAYagAAAAEOZWeqHMnQ5CEeyQJrMUwZ7FRbJZEwW73zL8hb83LtnfUMPhvNWnJuRzkLp97YA8TA==", "B85F1D2E74485E7C2CF1F7BA7B213E6D50B83BBD0AC2647B179CDBD5090783D45D409C6A30E51D90654727CA180D8DCDF1E78C8BF18488B2B07E291FE63B056B" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 2,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4678), new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4677), "AQAAAAIAAYagAAAAEKLCjs2ZCEwXxnHNZ4XmqMIbnlNWRh5qsJcZ3WoKTc+WvV8QucVBDCkVBjnG8/rn4g==", "4639AA1976006DC27F7F36F363D17EF0E5B4781FD69F556B0914F3293ABF2CFF84A9BD6012B29DE9C5C528C8F45B0479248F53A16015073C895DDE953081B4ED" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id_usuario",
                keyValue: 3,
                columns: new[] { "fecha_acceso", "fecha_creacion", "password_usuario", "salt_password" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4682), new DateTime(2023, 12, 6, 16, 8, 3, 157, DateTimeKind.Local).AddTicks(4681), "AQAAAAIAAYagAAAAEGztPYCAeuayMBgxmmsAqgpkcx+l1cmFgOqXLQof3mkfHJuDOvpVah6R35+3CNxGXA==", "944E245D11EC528F6DE5FE3107170A4F811C08FC4623668C123F9F92814AFE151588ED327141FBE528F87FA7C0E1959640F08A00A0888D6E5AF499535E5AAD07" });
        }
    }
}
