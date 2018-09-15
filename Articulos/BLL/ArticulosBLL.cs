﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Articulos.Entidades;
using Articulos.DAL;

namespace ArticulosBLL.BLL
{
    public class ArticulosBLL
    {
        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="Articulo">Una instancia de Articulo</param>
        /// <returns>Retorna True si guardo o Falso si falló </returns>
        public static bool Guardar(rArticulos articulo)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la BD
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Articulos.Add(articulo) != null)
                {
                    contexto.SaveChanges();//Guardar los cambios
                    paso = true;
                }
                contexto.Dispose();//siempre hay que cerrar la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Modificar una entidad en la base de datos 
        /// </summary>
        /// <param name="articulo">Una instancia de Articulo</param>
        /// <returns>Retorna True si Modifico o Falso si falló </returns>
        public static bool Modificar(rArticulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id del articulo que se desea eliminar </param>
        /// <returns>Retorna True si Eliminó o Falso si falló </returns>
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                rArticulos articulo = contexto.Articulos.Find(id);
                contexto.Articulos.Remove(articulo);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id del articulo que se desea encontrar </param>
        /// <returns>Retorna el articulo encontrado </returns>
        public static rArticulos Buscar(int id)
        {
            rArticulos articulo = new rArticulos();
            Contexto contexto = new Contexto();

            try
            {
                articulo = contexto.Articulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return articulo;
        }

        /// <summary>
        /// Permite extraer una lista de Articulos de la base de datos
        /// </summary> 
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        /// <returns>Retorna una lista de articulos</returns>
        public static List<rArticulos> GetList(Expression<Func<rArticulos, bool>> expression)
        {
            List<rArticulos> Articulos = new List<rArticulos>();
            Contexto contexto = new Contexto();

            try
            {
                Articulos = contexto.Articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Articulos;
        }
    }
}
