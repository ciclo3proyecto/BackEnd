using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class g5FtGnkAVWContext : DbContext
    {
        public g5FtGnkAVWContext()
        {
        }

        public g5FtGnkAVWContext(DbContextOptions<g5FtGnkAVWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Perfile> Perfiles { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Tiposdocumento> Tiposdocumentos { get; set; } = null!;
        public virtual DbSet<Tiposmovimiento> Tiposmovimientos { get; set; } = null!;
        public virtual DbSet<Unidade> Unidades { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=DatabaseConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.13-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.Property(e => e.Menu1)
                    .HasMaxLength(100)
                    .HasColumnName("menu");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(500)
                    .HasColumnName("ruta");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("movimientos");

                entity.HasIndex(e => e.ProductosId, "movimientos_productos_fk");

                entity.HasIndex(e => e.TiposmovimientosId, "movimientos_tiposmovimientos_fk");

                entity.HasIndex(e => e.Creadopor, "movimientos_usuarios_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Cantidad)
                    .HasPrecision(19, 2)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Precio)
                    .HasPrecision(19, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.ProductosId)
                    .HasColumnType("int(11)")
                    .HasColumnName("productos_id");

                entity.Property(e => e.TiposmovimientosId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tiposmovimientos_id");

                entity.HasOne(d => d.CreadoporNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.Creadopor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movimientos_usuarios_fk");

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.ProductosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movimientos_productos_fk");

                entity.HasOne(d => d.Tiposmovimientos)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TiposmovimientosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movimientos_tiposmovimientos_fk");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.ToTable("perfiles");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("permisos");

                entity.HasIndex(e => e.MenusId, "permisos_menus_fk");

                entity.HasIndex(e => e.PerfilId, "permisos_perfil_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.Property(e => e.MenusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("menus_id");

                entity.Property(e => e.PerfilId)
                    .HasColumnType("int(11)")
                    .HasColumnName("perfil_id");

                entity.HasOne(d => d.Menus)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.MenusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permisos_menus_fk");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permisos_perfil_fk");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.HasIndex(e => e.UnidadesId, "productos_unidades_fk");

                entity.HasIndex(e => e.Creadopor, "productos_usuarios_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .HasColumnName("codigo");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.Property(e => e.Existencia)
                    .HasPrecision(19, 2)
                    .HasColumnName("existencia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasPrecision(19, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.UnidadesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("unidades_id");

                entity.HasOne(d => d.CreadoporNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Creadopor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productos_usuarios_fk");

                entity.HasOne(d => d.Unidades)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.UnidadesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productos_unidades_fk");
            });

            modelBuilder.Entity<Tiposdocumento>(entity =>
            {
                entity.ToTable("tiposdocumentos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<Tiposmovimiento>(entity =>
            {
                entity.ToTable("tiposmovimientos");

                entity.HasIndex(e => e.Creadopor, "tiposmovimientos_usuarios_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Afectacion)
                    .HasMaxLength(1)
                    .HasColumnName("afectacion")
                    .IsFixedLength();

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.HasOne(d => d.CreadoporNavigation)
                    .WithMany(p => p.Tiposmovimientos)
                    .HasForeignKey(d => d.Creadopor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tiposmovimientos_usuarios_fk");
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.ToTable("unidades");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.PerfilesId, "usuarios_perfiles_fk");

                entity.HasIndex(e => e.TiposdocumentosId, "usuarios_tiposdocumentos_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Actualizado).HasColumnName("actualizado");

                entity.Property(e => e.Actualizadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("actualizadopor");

                entity.Property(e => e.Creado).HasColumnName("creado");

                entity.Property(e => e.Creadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("creadopor");

                entity.Property(e => e.Eliminado).HasColumnName("eliminado");

                entity.Property(e => e.Eliminadopor)
                    .HasColumnType("int(11)")
                    .HasColumnName("eliminadopor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(13)
                    .HasColumnName("estado");

                entity.Property(e => e.Identificacion)
                    .HasPrecision(28)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(250)
                    .HasColumnName("nombres");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PerfilesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("perfiles_id");

                entity.Property(e => e.Primerapellido)
                    .HasMaxLength(100)
                    .HasColumnName("primerapellido");

                entity.Property(e => e.Segundoapellido)
                    .HasMaxLength(100)
                    .HasColumnName("segundoapellido");

                entity.Property(e => e.TiposdocumentosId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tiposdocumentos_id");

                entity.HasOne(d => d.Perfiles)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PerfilesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_perfiles_fk");

                entity.HasOne(d => d.Tiposdocumentos)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TiposdocumentosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_tiposdocumentos_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
