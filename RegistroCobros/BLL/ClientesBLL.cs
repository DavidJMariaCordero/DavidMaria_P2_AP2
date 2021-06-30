using RegistroCobros.DAL;
using RegistroCobros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroCobros.BLL
{
    public class ClientesBLL
    {
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Clientes.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return lista;
        }
    }
}
