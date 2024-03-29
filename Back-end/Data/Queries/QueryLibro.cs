﻿using Domain.Entities;
using WebApplication1.Application.Interfaces.IQueries;

namespace WebApplication1.Data.Queries
{
    public class QueryLibro : IQueryLibro
    {
        private readonly LibreriaContext context;
        public QueryLibro(LibreriaContext contex)
        {
            this.context = contex;
        }
        public Libro BuscarLibro(string isbn)
        {
            return context.Libros.Find(isbn);
        }
        public List<Libro> BuscarAutor(string autor)
        {
            return context.Libros.Where(aut => aut.Autor == autor).ToList();
        }
        public Libro GetLibroByIsbn(string isbn)
        {
            return context.Libros.Where(l => l.ISBN == isbn).FirstOrDefault();
        }

        public int? Stock(string isbn)
        {
            return context.Libros.Where(l => l.ISBN.Equals(isbn)).Select(s => s.Stock).FirstOrDefault();
        }
        public List<Libro> ListaLibros(string isbn)
        {
            if(isbn != null)
            {
                return context.Libros.Where(l => l.ISBN == isbn).ToList();
            }
            return context.Libros.ToList();

        }
        public List<Libro> GetLibrosByFiltros(bool? stock, string autor, string titulo)
        {
            if (stock == null)
            {
                if (autor != null && titulo != null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor) &&
                                                       string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo)).ToList();
                }
                if (autor != null && titulo == null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor)).ToList();
                }
                if (autor == null && titulo != null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo)).ToList();
                }
                return context.Libros.ToList();
            }
            if ((bool)stock)
            {
                if (autor != null && titulo != null)
                {
                    return context.Libros.Where(lib => ((string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor)) &&
                                                        (string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo)) && lib.Stock > 0)).ToList();
                }
                if (autor != null && titulo == null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor) && lib.Stock > 0).ToList();
                }
                if (autor == null && titulo != null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo) && lib.Stock > 0).ToList();
                }
                return context.Libros.Where(l => l.Stock > 0).ToList();
            }
            else
            {
                if (autor != null && titulo != null)
                {
                    return context.Libros.Where(lib => ((string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor)) &&
                                                        (string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo)) && lib.Stock == 0)).ToList();
                }
                if (autor != null && titulo == null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(autor) || lib.Autor.Contains(autor) && lib.Stock == 0).ToList();
                }
                if (autor == null && titulo != null)
                {
                    return context.Libros.Where(lib => string.IsNullOrEmpty(titulo) || lib.Titulo.Contains(titulo) && lib.Stock == 0).ToList();
                }
                if (autor == null && titulo == null)
                {
                    return context.Libros.Where(lib => lib.Stock == 0).ToList();
                }
                return context.Libros.Where(lib => lib.Stock == 0).ToList();
            }
        }


        public List<Libro> GetLibrosByInput(string input)
        {
            if(input != null)
            {
                return context.Libros.Where(lib => string.IsNullOrEmpty(input) || lib.Autor.Contains(input) ||
                                                    string.IsNullOrEmpty(input) || lib.Titulo.Contains(input) ||
                                                    string.IsNullOrEmpty(input) || lib.ISBN.Contains(input)).ToList();
            }
            return context.Libros.ToList();
        }

        public List<Libro> ListaAutor(string autor)
        {
            return context.Libros.Where(l => l.Autor == autor).ToList();
        }
    }
}