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
        public DbSet<ComidaCombo> ComboComida { get; set; }
        public DbSet<ProductoCarrito> Carrito { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(); // Enable sensitive data logging
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Querys


            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Etiqueta).HasColumnType("varchar(13)");
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.EstadoUsuario)
                    .HasForeignKey<Usuario>(e => e.IdEstadoUsuario);

                entity
                    .HasOne(e => e.Comida)
                    .WithOne(e => e.EstadoComida)
                    .HasForeignKey<Comida>(e => e.IdEstadoComida);

                entity
                    .HasOne(e => e.Combo)
                    .WithOne(e => e.EstadoCombo)
                    .HasForeignKey<Combo>(e => e.IdEstadoCombo);
            });

            // Persona

            modelBuilder.Entity<Usuario>(entity =>
            {
                // Atributos
                entity.Property(e => e.IdTipoUsuario).HasColumnType("int");
                entity.Property(e => e.Nombre).HasColumnType("varchar(20)");
                entity.Property(e => e.SaltPassword).HasColumnType("text");
                entity.Property(e => e.Password).HasColumnType("text");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.FechaAcceso).HasColumnType("datetime");
                entity.Property(e => e.IdEstadoUsuario).HasColumnType("int");
                entity.Property(e => e.IdCliente).HasColumnType("int");
                // Foreign Key { Unique = false }
                entity.HasIndex(e => e.IdCliente).IsUnique(false);
                entity.HasIndex(e => e.IdTipoUsuario).IsUnique(false);
                entity.HasIndex(e => e.IdEstadoUsuario).IsUnique(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(20)");
                entity.Property(e => e.Apellido).HasColumnType("varchar(20)");
                entity.Property(e => e.FechaNacimiento).HasColumnType("date");
                entity.Property(e => e.TelefonoCliente).HasColumnType("varchar(12)");
                entity.Property(e => e.MailCliente).HasColumnType("text");
                entity
                    .ToTable(e => e.HasCheckConstraint("CK_Genero",
                    "[idGeneroCliente] = 1 OR [idGeneroCliente] = 2"));
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey<Usuario>(e => e.IdCliente);
                entity
                    .HasOne(e => e.Orden)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey<Orden>(e => e.IdCliente);
                entity.HasIndex(e => e.IdGenero).IsUnique(false);
            });

                    // Catalogos Persona

            modelBuilder.Entity<GeneroCliente>(entity =>
            {
                entity.Property(e => e.Etiqueta).HasColumnType("varchar(9)");
                entity
                    .HasOne(e => e.Cliente)
                    .WithOne(e => e.Genero)
                    .HasForeignKey<Cliente>(e => e.IdGenero);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Etiqueta).HasColumnType("varchar(13)");
                entity
                    .HasOne(e => e.Usuario)
                    .WithOne(e => e.TipoUsuario)
                    .HasForeignKey<Usuario>(e => e.IdTipoUsuario);
            });

            // Producto

            modelBuilder.Entity<Comida>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.HasIndex(e => e.IdEstadoComida).IsUnique(false);
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Precio).HasColumnType("decimal(2,1)");
                entity.HasIndex(e => e.IdCategoriaComida).IsUnique(false);
                entity
                    .HasOne(e => e.ComboComida)
                    .WithOne(e => e.Comida)
                    .HasForeignKey<ComidaCombo>(e => e.IdComida)
                    .OnDelete(DeleteBehavior.NoAction);
                entity
                    .HasOne(e => e.ComidaCarrito)
                    .WithOne(e => e.Comida)
                    .HasForeignKey<ComidaCarrito>(e => e.IdComida)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.HasIndex(e => e.IdEstadoCombo).IsUnique(false);
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Descuento).HasColumnType("decimal(1,1)");
                entity.Property(e => e.IdCategoriaCombo).HasColumnType("int");
                entity.HasIndex(e => e.IdCategoriaCombo).IsUnique(false);
                entity
                    .HasOne(e => e.ComboComida)
                    .WithOne(e => e.Combo)
                    .HasForeignKey<ComidaCombo>(e => e.IdCombo)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(e => e.ComboCarrito)
                    .WithOne(e => e.Combo)
                    .HasForeignKey<ComboCarrito>(e => e.IdCombo)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ComidaCombo>(entity =>
            {
                entity.HasIndex(e => e.IdCombo).IsUnique(false);
                entity.HasIndex(e => e.IdComida).IsUnique(false);
                entity.Property(e => e.Cantidad).HasColumnType("numeric(1,0)");
            });

                    // Catalagos Producto

            modelBuilder.Entity<CategoriaComida>(entity =>
            {
                entity.Property(e => e.Etiqueta).HasColumnType("varchar(30)");
                entity
                    .HasOne(e => e.Comida)
                    .WithOne(e => e.CategoriaComida)
                    .HasForeignKey<Comida>(e => e.IdCategoriaComida)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<CategoriaCombo>(entity =>
            {
                entity.Property(e => e.Etiqueta).HasColumnType("varchar(30)");
                entity
                    .HasOne(e => e.Combo)
                    .WithOne(e => e.CategoriaCombo)
                    .HasForeignKey<Combo>(e => e.IdCategoriaCombo)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Orden

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.HasIndex(e => e.IdCliente).IsUnique(false);
                entity
                    .HasOne(e => e.Carrito)
                    .WithOne(e => e.Orden)
                    .HasForeignKey<ProductoCarrito>(e => e.IdOrden);
            });

            modelBuilder.Entity<ProductoCarrito>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Cantidad).HasColumnType("numeric(2,0)");
                entity.HasIndex(e => e.IdOrden).IsUnique(false);
            });

            modelBuilder.Entity<ComidaCarrito>(entity =>
            {
                entity.HasIndex(e => e.IdComida).IsUnique(false);
                entity.HasIndex(e => e.IdComboCarrito).IsUnique(false);
            });

            modelBuilder.Entity<ComboCarrito>(entity =>
            {;
                entity.HasIndex(e => e.IdCombo).IsUnique(false);
                entity
                    .HasOne(e => e.ComidaCarrito)
                    .WithOne(e => e.ComboCarrito)
                    .HasForeignKey<ComidaCarrito>(e => e.IdComboCarrito)
                    .OnDelete(DeleteBehavior.NoAction);
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

            modelBuilder.Entity<ComidaCombo>().HasData(new ListaComboComida().listaComboComida);

            modelBuilder.Entity<Orden>().HasData(new ListaOrdenes().listaOrdenes);

            modelBuilder.Entity<ComboCarrito>().HasData(new ListaCombosCarrito().listaCombosCarrito);

            modelBuilder.Entity<ComidaCarrito>().HasData(new ListaComidasCarrito().listaComidasCarrito);
        }

    }

}
