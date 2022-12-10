﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JAvilesPTContainer : DbContext
    {
        public JAvilesPTContainer()
            : base("name=JAvilesPTContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Genero> Generoes { get; set; }
        public virtual DbSet<Libro> Libroes { get; set; }
    
        public virtual int AddLibro(string nombre, Nullable<int> idAutor, Nullable<int> numeroPaginas, Nullable<System.DateTime> fechaPublicacion, Nullable<int> idEditorial, string edicion, Nullable<int> idGenero)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var edicionParameter = edicion != null ?
                new ObjectParameter("Edicion", edicion) :
                new ObjectParameter("Edicion", typeof(string));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddLibro", nombreParameter, idAutorParameter, numeroPaginasParameter, fechaPublicacionParameter, idEditorialParameter, edicionParameter, idGeneroParameter);
        }
    
        public virtual int LibroDelete(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDelete", idLibroParameter);
        }
    
        public virtual ObjectResult<LibroGetAll_Result> LibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAll_Result>("LibroGetAll");
        }
    
        public virtual ObjectResult<LibroGetById_Result> LibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetById_Result>("LibroGetById", idLibroParameter);
        }
    
        public virtual int UpdateLibro(Nullable<int> idLibro, string nombre, Nullable<int> idAutor, Nullable<int> numeroPaginas, Nullable<System.DateTime> fechaPublicacion, Nullable<int> idEditorial, string edicion, Nullable<int> idGenero)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var edicionParameter = edicion != null ?
                new ObjectParameter("Edicion", edicion) :
                new ObjectParameter("Edicion", typeof(string));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateLibro", idLibroParameter, nombreParameter, idAutorParameter, numeroPaginasParameter, fechaPublicacionParameter, idEditorialParameter, edicionParameter, idGeneroParameter);
        }
    }
}