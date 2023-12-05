﻿using System;
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
                    id_categoria_combo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_categoria_combo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasCombo", x => x.id_categoria_combo);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasComida",
                columns: table => new
                {
                    id_categoria_comida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_categoria_comida = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasComida", x => x.id_categoria_comida);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_estado = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genero_cliente = table.Column<string>(type: "varchar(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id_genero);
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
                    id_tipo_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_usuario = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.id_tipo_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descuento_combo = table.Column<decimal>(type: "decimal(1,1)", nullable: false),
                    id_categoria_combo = table.Column<int>(type: "int", nullable: true),
                    estado_combo = table.Column<int>(type: "int", nullable: false),
                    nombre_producto = table.Column<string>(type: "varchar(30)", nullable: false),
                    descripcion_producto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Combos_CategoriasCombo_id_categoria_combo",
                        column: x => x.id_categoria_combo,
                        principalTable: "CategoriasCombo",
                        principalColumn: "id_categoria_combo",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Combos_Estados_estado_combo",
                        column: x => x.estado_combo,
                        principalTable: "Estados",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio_comida = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    id_categoria_comida = table.Column<int>(type: "int", nullable: true),
                    estado_comida = table.Column<int>(type: "int", nullable: false),
                    nombre_producto = table.Column<string>(type: "varchar(30)", nullable: false),
                    descripcion_producto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Comidas_CategoriasComida_id_categoria_comida",
                        column: x => x.id_categoria_comida,
                        principalTable: "CategoriasComida",
                        principalColumn: "id_categoria_comida",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comidas_Estados_estado_comida",
                        column: x => x.estado_comida,
                        principalTable: "Estados",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_cliente = table.Column<string>(type: "varchar(20)", nullable: false),
                    apellido_cliente = table.Column<string>(type: "varchar(20)", nullable: false),
                    fechaN_cliente = table.Column<DateTime>(type: "date", nullable: false),
                    id_genero_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                    table.CheckConstraint("CK_Genero", "[id_genero_cliente] = 1 OR [id_genero_cliente] = 2");
                    table.ForeignKey(
                        name: "FK_Clientes_Generos_id_genero_cliente",
                        column: x => x.id_genero_cliente,
                        principalTable: "Generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboComida",
                columns: table => new
                {
                    combo_comida_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_combo = table.Column<int>(type: "int", nullable: false),
                    id_comida = table.Column<int>(type: "int", nullable: false),
                    cantidad_combo_comida = table.Column<decimal>(type: "numeric(1,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboComida", x => x.combo_comida_id);
                    table.ForeignKey(
                        name: "FK_ComboComida_Combos_id_combo",
                        column: x => x.id_combo,
                        principalTable: "Combos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK_ComboComida_Comidas_id_comida",
                        column: x => x.id_comida,
                        principalTable: "Comidas",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    id_orden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_compra_orden = table.Column<DateTime>(type: "date", nullable: false),
                    cliente_id_orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.id_orden);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_cliente_id_orden",
                        column: x => x.cliente_id_orden,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tipo_usuario = table.Column<int>(type: "int", nullable: false),
                    nombre_usuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    salt_password = table.Column<string>(type: "text", nullable: false),
                    password_usuario = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_acceso = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado_usuario = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_estado_usuario",
                        column: x => x.estado_usuario,
                        principalTable: "Estados",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_id_tipo_usuario",
                        column: x => x.id_tipo_usuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "id_tipo_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    id_carrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_orden_carrito = table.Column<int>(type: "int", nullable: false),
                    id_cantidad_carrito = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_combo_combo_carrito = table.Column<int>(type: "int", nullable: true),
                    id_combo_comida_carrito = table.Column<int>(name: "id_combo_comida_carrito)", type: "int", nullable: true),
                    id_comida_comida_carrito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.id_carrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Carrito_id_combo_comida_carrito)",
                        column: x => x.id_combo_comida_carrito,
                        principalTable: "Carrito",
                        principalColumn: "id_carrito");
                    table.ForeignKey(
                        name: "FK_Carrito_Combos_id_combo_combo_carrito",
                        column: x => x.id_combo_combo_carrito,
                        principalTable: "Combos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK_Carrito_Comidas_id_comida_comida_carrito",
                        column: x => x.id_comida_comida_carrito,
                        principalTable: "Comidas",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK_Carrito_Ordenes_id_orden_carrito",
                        column: x => x.id_orden_carrito,
                        principalTable: "Ordenes",
                        principalColumn: "id_orden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriasCombo",
                columns: new[] { "id_categoria_combo", "nombre_categoria_combo" },
                values: new object[,]
                {
                    { 1, "ComboCarrito Familiar" },
                    { 2, "ComboCarrito Individual" },
                    { 3, "ComboCarrito Infantil" }
                });

            migrationBuilder.InsertData(
                table: "CategoriasComida",
                columns: new[] { "id_categoria_comida", "nombre_categoria_comida" },
                values: new object[,]
                {
                    { 1, "Hamburguesa" },
                    { 2, "Bebida" },
                    { 3, "Complemento" },
                    { 4, "Postre" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "id_estado", "nombre_estado" },
                values: new object[,]
                {
                    { 1, "Habililtado" },
                    { 2, "Deshabilitado" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "id_genero", "genero_cliente" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "id_tipo_usuario", "tipo_usuario" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id_cliente", "apellido_cliente", "fechaN_cliente", "id_genero_cliente", "nombre_cliente" },
                values: new object[,]
                {
                    { 1, "Jácome", new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Christian" },
                    { 2, "Jácome", new DateTime(2007, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xavier" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "id_producto", "id_categoria_combo", "descripcion_producto", "descuento_combo", "estado_combo", "nombre_producto" },
                values: new object[,]
                {
                    { 1, 2, "El combo clásico incluye una hamburguesa con queso,\r\nacompañada por papas fritas y una bebida refrescante.", 0.3m, 1, "ComboCarrito Clásico" },
                    { 2, 1, "El Combo \"Para Todos\" ofrece hamburguesas individuales\r\nvariadas con nachos cubiertos de sabores intensos,\r\npapas fritas especiales y una jarra grande de bebidas refrescantes.\r\n¡Ideal para satisfacer los gustos de todos en el grupo!", 0.2m, 1, "ComboCarrito Para Todos" },
                    { 3, 3, "El Combo \"Mini Burguer\" ofrece una hamburguesa pequeña\r\ncon queso y vegetales, acompañada de papas fritas y\r\nuna bebida refrescante, perfecto para los más pequeños.", 0.1m, 1, "ComboCarrito Mini Burguer" }
                });

            migrationBuilder.InsertData(
                table: "Comidas",
                columns: new[] { "id_producto", "id_categoria_comida", "descripcion_producto", "estado_comida", "nombre_producto", "precio_comida" },
                values: new object[,]
                {
                    { 1, 1, "Una hamburguesa con queso, lechuga, tomate, cebolla y salsa especial.", 1, "Hamburguesa Clásica", 5.5m },
                    { 2, 1, "Doble carne con queso, tocino, lechuga, tomate y aderezos.", 1, "Hamburguesa Doble", 7.5m },
                    { 3, 1, "Una hamburguesa más pequeña con queso y vegetales básicos.", 1, "Mini Hamburguesa Sencilla", 3.5m },
                    { 4, 3, "Papas fritas grandes", 1, "Papas Fritas Grandes", 2.5m },
                    { 5, 3, "Papas fritas pequeñas", 1, "Papas Fritas Pequeñas", 1.5m },
                    { 6, 2, "Coca Cola personal de 500 ml", 1, "Coca Cola (500ml)", 2.5m },
                    { 7, 4, "Helado de vainilla", 1, "Helado de Vainilla", 1.5m },
                    { 8, 4, "Helado de chocalate", 1, "Helado de Chocolate", 1.5m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id_usuario", "id_cliente", "estado_usuario", "fecha_acceso", "fecha_creacion", "nombre_usuario", "password_usuario", "salt_password", "id_tipo_usuario" },
                values: new object[] { 1, null, 1, new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7506), new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7492), "admin", "AQAAAAIAAYagAAAAELNPoSIDhuaw8WZMK2R1VtjDupswGSDnvYNsygcN0rlVnG4NvUHLQY8gxeXokFyOUg==", "170965456C39FC5D25C3C8E5E93E2F3909812BEC7B2BF2BE5044DCED6486B6523D971B1119FF8DBD70693223F9EE01B286D8917B76E0418FBAD2FB8A91DA2AFD", 1 });

            migrationBuilder.InsertData(
                table: "ComboComida",
                columns: new[] { "combo_comida_id", "cantidad_combo_comida", "id_combo", "id_comida" },
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
                columns: new[] { "id_orden", "cliente_id_orden", "fecha_compra_orden" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 4, 18, 8, 56, 824, DateTimeKind.Local).AddTicks(4188) },
                    { 2, 2, new DateTime(2023, 12, 4, 18, 8, 56, 824, DateTimeKind.Local).AddTicks(4227) }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id_usuario", "id_cliente", "estado_usuario", "fecha_acceso", "fecha_creacion", "nombre_usuario", "password_usuario", "salt_password", "id_tipo_usuario" },
                values: new object[,]
                {
                    { 2, 1, 1, new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7514), new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7514), "chris2003", "AQAAAAIAAYagAAAAEH56EzP7y8NgIT+LUJSr3y93z98iSCuHmA0FXVXjuYnE83wex2cs4phbnJjKcOjcsw==", "6BCB48B6F17F890FE18E2E542A5A883615EBA70BB83A402766A99E0DF5B1B215700D16C3B2691081FADF50D9D0C63FCDCDC8B233AD8212A40BA5C39E03B18483", 2 },
                    { 3, 2, 1, new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7519), new DateTime(2023, 12, 4, 18, 8, 56, 588, DateTimeKind.Local).AddTicks(7518), "xavier2007", "AQAAAAIAAYagAAAAEH0cYlqM04fVp+vv6mOuVxIRx7BZSYL6YaOgbPjVijwA16iYOq0yqYYGqphe9u7kYg==", "10C7305832E3D6955B0B6E1B0FA2448EF6389024452B3602848F0B067D0BF83ADC9C80AF8AFE15580F0964594CC81D40F52B36591E4629FC64B79AFECAB724D2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "id_carrito", "id_cantidad_carrito", "id_combo_combo_carrito", "Discriminator", "id_orden_carrito" },
                values: new object[,]
                {
                    { 1, 3m, 1, "ComboCarrito", 1 },
                    { 2, 2m, 1, "ComboCarrito", 1 },
                    { 3, 1m, 3, "ComboCarrito", 2 }
                });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "id_carrito", "id_cantidad_carrito", "id_combo_comida_carrito)", "id_comida_comida_carrito", "Discriminator", "id_orden_carrito" },
                values: new object[,]
                {
                    { 17, 4m, null, 2, "ComidaCarrito", 2 },
                    { 18, 2m, null, 6, "ComidaCarrito", 2 },
                    { 4, 3m, 1, 1, "ComidaCarrito", 1 },
                    { 5, 5m, 1, 5, "ComidaCarrito", 1 },
                    { 6, 5m, 1, 6, "ComidaCarrito", 1 },
                    { 7, 2m, 1, 7, "ComidaCarrito", 1 },
                    { 8, 2m, 2, 1, "ComidaCarrito", 1 },
                    { 9, 3m, 2, 4, "ComidaCarrito", 1 },
                    { 10, 3m, 2, 6, "ComidaCarrito", 1 },
                    { 11, 1m, 2, 8, "ComidaCarrito", 1 },
                    { 13, 1m, 3, 3, "ComidaCarrito", 2 },
                    { 14, 3m, 3, 5, "ComidaCarrito", 2 },
                    { 15, 3m, 3, 6, "ComidaCarrito", 2 },
                    { 16, 3m, 3, 7, "ComidaCarrito", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_id_combo_combo_carrito",
                table: "Carrito",
                column: "id_combo_combo_carrito");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_id_combo_comida_carrito)",
                table: "Carrito",
                column: "id_combo_comida_carrito)");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_id_comida_comida_carrito",
                table: "Carrito",
                column: "id_comida_comida_carrito");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_id_orden_carrito",
                table: "Carrito",
                column: "id_orden_carrito");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_id_genero_cliente",
                table: "Clientes",
                column: "id_genero_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_id_combo",
                table: "ComboComida",
                column: "id_combo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_id_comida",
                table: "ComboComida",
                column: "id_comida");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_estado_combo",
                table: "Combos",
                column: "estado_combo");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_id_categoria_combo",
                table: "Combos",
                column: "id_categoria_combo");

            migrationBuilder.CreateIndex(
                name: "IX_Comidas_estado_comida",
                table: "Comidas",
                column: "estado_comida");

            migrationBuilder.CreateIndex(
                name: "IX_Comidas_id_categoria_comida",
                table: "Comidas",
                column: "id_categoria_comida");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_cliente_id_orden",
                table: "Ordenes",
                column: "cliente_id_orden");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_estado_usuario",
                table: "Usuarios",
                column: "estado_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_cliente",
                table: "Usuarios",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_tipo_usuario",
                table: "Usuarios",
                column: "id_tipo_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_nombre_usuario",
                table: "Usuarios",
                column: "nombre_usuario",
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