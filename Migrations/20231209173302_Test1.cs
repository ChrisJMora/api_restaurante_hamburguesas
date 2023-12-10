using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_restaurante_hamburguesas.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasCombo",
                columns: table => new
                {
                    idCategoriaCombo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etiquetaCategoriaCombo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasCombo", x => x.idCategoriaCombo);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasComida",
                columns: table => new
                {
                    idCategoriaComida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etiquetaCategoriaComida = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasComida", x => x.idCategoriaComida);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etiquetaEstado = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    idGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etiquetaGenero = table.Column<string>(type: "varchar(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.idGenero);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    id_imagen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo_imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datos_imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.id_imagen);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    idTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etiquetaTipo = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.idTipo);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "varchar(30)", nullable: false),
                    descripcionProducto = table.Column<string>(type: "text", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(1,1)", nullable: false),
                    idEstadoCombo = table.Column<int>(type: "int", nullable: false),
                    idCategoriaCombo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Combos_CategoriasCombo_idCategoriaCombo",
                        column: x => x.idCategoriaCombo,
                        principalTable: "CategoriasCombo",
                        principalColumn: "idCategoriaCombo",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Combos_Estados_idEstadoCombo",
                        column: x => x.idEstadoCombo,
                        principalTable: "Estados",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "varchar(30)", nullable: false),
                    descripcionProducto = table.Column<string>(type: "text", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    idCategoriaComida = table.Column<int>(type: "int", nullable: true),
                    idEstadoComida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Comidas_CategoriasComida_idCategoriaComida",
                        column: x => x.idCategoriaComida,
                        principalTable: "CategoriasComida",
                        principalColumn: "idCategoriaComida",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comidas_Estados_idEstadoComida",
                        column: x => x.idEstadoComida,
                        principalTable: "Estados",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(type: "varchar(20)", nullable: false),
                    apellido = table.Column<string>(type: "varchar(20)", nullable: false),
                    fechaNcliente = table.Column<DateTime>(type: "date", nullable: false),
                    idGeneroCliente = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "varchar(12)", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                    table.CheckConstraint("CK_Genero", "[idGeneroCliente] = 1 OR [idGeneroCliente] = 2");
                    table.ForeignKey(
                        name: "FK_Clientes_Generos_idGeneroCliente",
                        column: x => x.idGeneroCliente,
                        principalTable: "Generos",
                        principalColumn: "idGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboComida",
                columns: table => new
                {
                    idCombo = table.Column<int>(type: "int", nullable: false),
                    idComida = table.Column<int>(type: "int", nullable: false),
                    cantidadComidaCombo = table.Column<decimal>(type: "numeric(1,0)", nullable: false),
                    idComidaCombo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboComida", x => x.idComidaCombo);
                    table.ForeignKey(
                        name: "FK_ComboComida_Combos_idCombo",
                        column: x => x.idCombo,
                        principalTable: "Combos",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboComida_Comidas_idComida",
                        column: x => x.idComida,
                        principalTable: "Comidas",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    idOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaOrden = table.Column<DateTime>(type: "datetime", nullable: false),
                    idClienteOrden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.idOrden);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_idClienteOrden",
                        column: x => x.idClienteOrden,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    nombreUsuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    saltPassword = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaAcceso = table.Column<DateTime>(type: "datetime", nullable: false),
                    idEstadoUsuario = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_idEstadoUsuario",
                        column: x => x.idEstadoUsuario,
                        principalTable: "Estados",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "idTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    idCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idOrdenCarrito = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCombo = table.Column<int>(type: "int", nullable: true),
                    idComboCarrito = table.Column<int>(type: "int", nullable: true),
                    idComida = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.idCarrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Carrito_idComboCarrito",
                        column: x => x.idComboCarrito,
                        principalTable: "Carrito",
                        principalColumn: "idCarrito");
                    table.ForeignKey(
                        name: "FK_Carrito_Combos_idCombo",
                        column: x => x.idCombo,
                        principalTable: "Combos",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK_Carrito_Comidas_idComida",
                        column: x => x.idComida,
                        principalTable: "Comidas",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK_Carrito_Ordenes_idOrdenCarrito",
                        column: x => x.idOrdenCarrito,
                        principalTable: "Ordenes",
                        principalColumn: "idOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriasCombo",
                columns: new[] { "idCategoriaCombo", "etiquetaCategoriaCombo" },
                values: new object[,]
                {
                    { 1, "ComboCarrito Familiar" },
                    { 2, "ComboCarrito Individual" },
                    { 3, "ComboCarrito Infantil" }
                });

            migrationBuilder.InsertData(
                table: "CategoriasComida",
                columns: new[] { "idCategoriaComida", "etiquetaCategoriaComida" },
                values: new object[,]
                {
                    { 1, "Hamburguesa" },
                    { 2, "Bebida" },
                    { 3, "Complemento" },
                    { 4, "Postre" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "idEstado", "etiquetaEstado" },
                values: new object[,]
                {
                    { 1, "Habililtado" },
                    { 2, "Deshabilitado" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "idGenero", "etiquetaGenero" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "idTipo", "etiquetaTipo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "idCliente", "apellido", "fechaNcliente", "idGeneroCliente", "mail", "nombreCliente", "telefono" },
                values: new object[,]
                {
                    { 1, "Jácome", new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "chrisjMora@gmail.com", "Christian", "0992724743" },
                    { 2, "Jácome", new DateTime(2007, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "xavierjMora@gmail.com", "Xavier", "0992755743" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "idProducto", "descripcionProducto", "descuento", "idCategoriaCombo", "idEstadoCombo", "nombreProducto" },
                values: new object[,]
                {
                    { 1, "El combo clásico incluye una hamburguesa con queso,\r\nacompañada por papas fritas y una bebida refrescante.", 0.3m, 2, 1, "ComboCarrito Clásico" },
                    { 2, "El Combo \"Para Todos\" ofrece hamburguesas individuales\r\nvariadas con nachos cubiertos de sabores intensos,\r\npapas fritas especiales y una jarra grande de bebidas refrescantes.\r\n¡Ideal para satisfacer los gustos de todos en el grupo!", 0.2m, 1, 1, "ComboCarrito Para Todos" },
                    { 3, "El Combo \"Mini Burguer\" ofrece una hamburguesa pequeña\r\ncon queso y vegetales, acompañada de papas fritas y\r\nuna bebida refrescante, perfecto para los más pequeños.", 0.1m, 3, 1, "ComboCarrito Mini Burguer" }
                });

            migrationBuilder.InsertData(
                table: "Comidas",
                columns: new[] { "idProducto", "descripcionProducto", "idCategoriaComida", "idEstadoComida", "nombreProducto", "precio" },
                values: new object[,]
                {
                    { 1, "Una hamburguesa con queso, lechuga, tomate, cebolla y salsa especial.", 1, 1, "Hamburguesa Clásica", 5.5m },
                    { 2, "Doble carne con queso, tocino, lechuga, tomate y aderezos.", 1, 1, "Hamburguesa Doble", 7.5m },
                    { 3, "Una hamburguesa más pequeña con queso y vegetales básicos.", 1, 1, "Mini Hamburguesa Sencilla", 3.5m },
                    { 4, "Papas fritas grandes", 3, 1, "Papas Fritas Grandes", 2.5m },
                    { 5, "Papas fritas pequeñas", 3, 1, "Papas Fritas Pequeñas", 1.5m },
                    { 6, "Coca Cola personal de 500 ml", 2, 1, "Coca Cola (500ml)", 2.5m },
                    { 7, "Helado de vainilla", 4, 1, "Helado de Vainilla", 1.5m },
                    { 8, "Helado de chocalate", 4, 1, "Helado de Chocolate", 1.5m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "fechaAcceso", "fechaCreacion", "idCliente", "idEstadoUsuario", "idTipoUsuario", "nombreUsuario", "password", "saltPassword" },
                values: new object[] { 1, new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9246), new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9237), null, 1, 1, "admin", "AQAAAAIAAYagAAAAEMn1pwTkHKvqC6cBNqe0fHffYIfGbNcP4PB0ahFgoFeQZxzXkMRnsONBvWvi8iuPSA==", "99C56A3A3DADD9A29072760459D9672582B8B010A3C4E793861AD86F370A7D4B521ED95A77A55E6C32D0FB5298D4CD33CB8FDEF5EE5FDE2D4CF4C67824754AF2" });

            migrationBuilder.InsertData(
                table: "ComboComida",
                columns: new[] { "idComidaCombo", "cantidadComidaCombo", "idCombo", "idComida" },
                values: new object[,]
                {
                    { 1, 1m, 1, 1 },
                    { 2, 1m, 1, 4 },
                    { 3, 3m, 1, 5 },
                    { 4, 1m, 1, 6 },
                    { 5, 1m, 1, 7 },
                    { 6, 1m, 1, 8 },
                    { 7, 3m, 2, 2 },
                    { 8, 3m, 2, 4 },
                    { 9, 6m, 2, 5 },
                    { 10, 3m, 2, 6 },
                    { 11, 2m, 2, 7 },
                    { 12, 2m, 2, 8 },
                    { 13, 1m, 3, 3 },
                    { 14, 1m, 3, 5 },
                    { 15, 1m, 3, 6 },
                    { 16, 1m, 3, 7 },
                    { 17, 1m, 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Ordenes",
                columns: new[] { "idOrden", "idClienteOrden", "fechaOrden" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 9, 12, 33, 2, 27, DateTimeKind.Local).AddTicks(4048) },
                    { 2, 2, new DateTime(2023, 12, 9, 12, 33, 2, 27, DateTimeKind.Local).AddTicks(4083) }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "fechaAcceso", "fechaCreacion", "idCliente", "idEstadoUsuario", "idTipoUsuario", "nombreUsuario", "password", "saltPassword" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9252), new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9252), 1, 1, 2, "chris2003", "AQAAAAIAAYagAAAAEGSERbHFzt/GljZkX14qPcCJv81+SOPGQ/PTDwWdUK61ZnssxDF95SAwtGiBynjvSg==", "A913AEE3E5D5E10AA9D3BC6A15AABCF03C26D42B2B86E56F1E5EBA5BA08D21461C5A290442E4EC2ACC70D577A3617332AE051D497186046CECCE51B6B5F9F3BF" },
                    { 3, new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9254), new DateTime(2023, 12, 9, 12, 33, 1, 899, DateTimeKind.Local).AddTicks(9254), 2, 1, 2, "xavier2007", "AQAAAAIAAYagAAAAEIVOh+vrmrl7lXuqQ4MgE+eGwbznBHLi4MRxpslrKhjJTVlv2yvCnPSqrc2Vwad6dQ==", "E8D1A0131B01CC4B1B20CB44880BB927D8AFEBE1E1F3515049C374FDE966B277B7C85EDE2E83D6935D535388562D7952E82AE145769BCB807B80F2C9F8BA1FDF" }
                });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "idCarrito", "cantidad", "Discriminator", "idCombo", "idOrdenCarrito" },
                values: new object[,]
                {
                    { 1, 3m, "ComboCarrito", 1, 1 },
                    { 2, 2m, "ComboCarrito", 1, 1 },
                    { 3, 1m, "ComboCarrito", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "idCarrito", "cantidad", "Discriminator", "idComboCarrito", "idComida", "idOrdenCarrito" },
                values: new object[,]
                {
                    { 17, 4m, "ComidaCarrito", null, 2, 2 },
                    { 18, 2m, "ComidaCarrito", null, 6, 2 },
                    { 4, 3m, "ComidaCarrito", 1, 2, 1 },
                    { 5, 5m, "ComidaCarrito", 1, 5, 1 },
                    { 6, 5m, "ComidaCarrito", 1, 6, 1 },
                    { 7, 2m, "ComidaCarrito", 1, 7, 1 },
                    { 8, 2m, "ComidaCarrito", 2, 1, 1 },
                    { 9, 3m, "ComidaCarrito", 2, 4, 1 },
                    { 10, 3m, "ComidaCarrito", 2, 6, 1 },
                    { 11, 1m, "ComidaCarrito", 2, 8, 1 },
                    { 13, 1m, "ComidaCarrito", 3, 3, 2 },
                    { 14, 3m, "ComidaCarrito", 3, 5, 2 },
                    { 15, 3m, "ComidaCarrito", 3, 6, 2 },
                    { 16, 3m, "ComidaCarrito", 3, 7, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idCombo",
                table: "Carrito",
                column: "idCombo");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idComboCarrito",
                table: "Carrito",
                column: "idComboCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idComida",
                table: "Carrito",
                column: "idComida");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idOrdenCarrito",
                table: "Carrito",
                column: "idOrdenCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_idGeneroCliente",
                table: "Clientes",
                column: "idGeneroCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_idCombo",
                table: "ComboComida",
                column: "idCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_idComida",
                table: "ComboComida",
                column: "idComida");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_idCategoriaCombo",
                table: "Combos",
                column: "idCategoriaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_idEstadoCombo",
                table: "Combos",
                column: "idEstadoCombo");

            migrationBuilder.CreateIndex(
                name: "IX_Comidas_idCategoriaComida",
                table: "Comidas",
                column: "idCategoriaComida");

            migrationBuilder.CreateIndex(
                name: "IX_Comidas_idEstadoComida",
                table: "Comidas",
                column: "idEstadoComida");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_idClienteOrden",
                table: "Ordenes",
                column: "idClienteOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idCliente",
                table: "Usuarios",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idEstadoUsuario",
                table: "Usuarios",
                column: "idEstadoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idTipoUsuario",
                table: "Usuarios",
                column: "idTipoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_nombreUsuario",
                table: "Usuarios",
                column: "nombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "ComboComida");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Comidas");

            migrationBuilder.DropTable(
                name: "TiposUsuario");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CategoriasCombo");

            migrationBuilder.DropTable(
                name: "CategoriasComida");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
