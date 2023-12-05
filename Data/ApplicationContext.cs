using api_restaurante_hamburguesas.Models;
using api_restaurante_hamburguesas.Models.Orden;
using api_restaurante_hamburguesas.Models.Persona;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Models.Productos;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using api_restaurante_hamburguesas.Utils;
using api_restaurante_hamburguesas.Utils.Orden;
using api_restaurante_hamburguesas.Utils.Persona;
using api_restaurante_hamburguesas.Utils.Persona.Catalogos;
using api_restaurante_hamburguesas.Utils.Productos;
using api_restaurante_hamburguesas.Utils.Productos.Catalogos;
using Microsoft.EntityFrameworkCore;

namespace API_restauranteHamburguesas.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GeneroCliente> Generos { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<CategoriaComida> CategoriasComida { get; set; }
        public DbSet<CategoriaCombo> CategoriasCombo { get; set; }
        public DbSet<ComboComida> ComboComida { get; set; }
        public DbSet<ProductoCarrito> Carrito { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Querys


            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(13)");
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.EstadoUsuario)
                    .HasForeignKey<Usuario>(e => e.EstadoUsuarioId);

                entity
                    .HasOne(e => e.Comida)
                    .WithOne(e => e.EstadoComida)
                    .HasForeignKey<Comida>(e => e.EstadoComidaId);

                entity
                    .HasOne(e => e.Combo)
                    .WithOne(e => e.EstadoCombo)
                    .HasForeignKey<Combo>(e => e.EstadoComboId);
            });

            // Persona

            modelBuilder.Entity<Usuario>(entity =>
            {
                // Atributos
                entity.Property(e => e.TipoUsuarioId).HasColumnType("int");
                entity.Property(e => e.NombreUsuario).HasColumnType("varchar(20)");
                entity.Property(e => e.SaltPassword).HasColumnType("text");
                entity.Property(e => e.PasswordUsuario).HasColumnType("text");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.FechaAcceso).HasColumnType("datetime");
                entity.Property(e => e.EstadoUsuarioId).HasColumnType("int");
                entity.Property(e => e.ClienteId).HasColumnType("int");
                // Foreign Key { Unique = false }
                entity.HasIndex(e => e.ClienteId).IsUnique(false);
                entity.HasIndex(e => e.TipoUsuarioId).IsUnique(false);
                entity.HasIndex(e => e.EstadoUsuarioId).IsUnique(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(20)");
                entity.Property(e => e.Apellido).HasColumnType("varchar(20)");
                entity.Property(e => e.FechaNacimiento).HasColumnType("date");
                entity
                    .ToTable(e => e.HasCheckConstraint("CK_Genero",
                    "[id_genero_cliente] = 1 OR [id_genero_cliente] = 2"));
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey<Usuario>(e => e.ClienteId);
                entity
                    .HasOne(e => e.Orden)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey<Orden>(e => e.ClienteId_Orden);
                entity.HasIndex(e => e.GeneroId_Cliente).IsUnique(false);
            });

                    // Catalogos Persona

            modelBuilder.Entity<GeneroCliente>(entity =>
            {
                entity.Property(e => e.Genero).HasColumnType("varchar(9)");
                entity
                    .HasOne(e => e.Cliente)
                    .WithOne(e => e.Genero)
                    .HasForeignKey<Cliente>(e => e.GeneroId_Cliente);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Tipo).HasColumnType("varchar(13)");
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.TipoUsuario)
                    .HasForeignKey<Usuario>(e => e.TipoUsuarioId);
            });

            // Producto

            modelBuilder.Entity<Comida>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.HasIndex(e => e.EstadoComidaId).IsUnique(false);
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Precio).HasColumnType("decimal(2,1)");
                entity.HasIndex(e => e.CategoriaId_Comida).IsUnique(false);
                entity
                    .HasOne(e => e.ComboComida)
                    .WithOne(e => e.Comida)
                    .HasForeignKey<ComboComida>(e => e.IdComida)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.ComidaCarrito)
                    .WithOne(e => e.Comida)
                    .HasForeignKey<ComidaCarrito>(e => e.ComidaId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.HasIndex(e => e.EstadoComboId).IsUnique(false);
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Descuento).HasColumnType("decimal(1,1)");
                entity.Property(e => e.CategoriaId_Combo).HasColumnType("int");
                entity.HasIndex(e => e.CategoriaId_Combo).IsUnique(false);
                entity
                    .HasOne(e => e.ComboComida)
                    .WithOne(e => e.Combo)
                    .HasForeignKey<ComboComida>(e => e.IdCombo)
                    .OnDelete(DeleteBehavior.NoAction);
                entity
                    .HasOne(e => e.ComboCarrito)
                    .WithOne(e => e.Combo)
                    .HasForeignKey<ComboCarrito>(e => e.ComboId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ComboComida>(entity =>
            {
                entity.HasIndex(e => e.IdCombo).IsUnique(false);
                entity.HasIndex(e => e.IdComida).IsUnique(false);
                entity.Property(e => e.Cantidad).HasColumnType("numeric(1,0)");
            });

                    // Catalagos Producto

            modelBuilder.Entity<CategoriaComida>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity
                    .HasOne(e => e.Comida)
                    .WithOne(e => e.CategoriaComida)
                    .HasForeignKey<Comida>(e => e.CategoriaId_Comida)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<CategoriaCombo>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity
                    .HasOne(e => e.Combo)
                    .WithOne(e => e.CategoriaCombo)
                    .HasForeignKey<Combo>(e => e.CategoriaId_Combo)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Orden

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");
                entity.HasIndex(e => e.ClienteId_Orden).IsUnique(false);
                entity
                    .HasOne(e => e.Carrito)
                    .WithOne(e => e.Orden)
                    .HasForeignKey<ProductoCarrito>(e => e.OrdenId);
            });

            modelBuilder.Entity<ProductoCarrito>(entity =>
            {
                entity.Property(e => e.ProductoCarritoId).ValueGeneratedOnAdd();
                entity.Property(e => e.Cantidad).HasColumnType("numeric(2,0)");
                entity.HasIndex(e => e.OrdenId).IsUnique(false);
            });

            modelBuilder.Entity<ComidaCarrito>(entity =>
            {
                entity.HasIndex(e => e.ComidaId).IsUnique(false);
            });

            modelBuilder.Entity<ComboCarrito>(entity =>
            {;
                entity.HasIndex(e => e.ComboId).IsUnique(false);
            });

            // Contenido

            modelBuilder.Entity<Usuario>().HasData(new ListaUsuarios().usuarios);

            modelBuilder.Entity<TipoUsuario>().HasData(new ListaTiposUsuario().tiposUsuario);

            modelBuilder.Entity<Estado>().HasData(new ListaEstados().estados);

            modelBuilder.Entity<GeneroCliente>().HasData(new ListaGenerosCliente().generos);

            modelBuilder.Entity<Cliente>().HasData(new ListaClientes().clientes);

            modelBuilder.Entity<CategoriaComida>().HasData(new ListaCategoriasComida().categoriasComida);

            modelBuilder.Entity<CategoriaCombo>().HasData(new ListaCategoriasCombo().categoriasCombo);

            modelBuilder.Entity<Comida>().HasData(new ListaComidas().listaComidas);

            modelBuilder.Entity<Combo>().HasData(new ListaCombos().listasCombos);

            modelBuilder.Entity<ComboComida>().HasData(new ListaComboComida().listaComboComida);

            modelBuilder.Entity<Orden>().HasData(new ListaOrdenes().listaOrdenes);

            modelBuilder.Entity<ComboCarrito>().HasData(new ListaCombosCarrito().listaCombosCarrito);

            modelBuilder.Entity<ComidaCarrito>().HasData(new ListaComidasCarrito().listaComidasCarrito);
        }

    }

}
