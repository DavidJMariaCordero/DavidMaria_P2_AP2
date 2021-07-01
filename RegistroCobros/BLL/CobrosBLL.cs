using Microsoft.EntityFrameworkCore;
using RegistroCobros.DAL;
using RegistroCobros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCobros.BLL
{
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            if (!Existe(cobro.CobroId))
                return Insertar(cobro);
            else
                return false;
        }

        private static bool Insertar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                
                foreach (var item in cobro.Detalle)
                {
                    Ventas venta = contexto.Ventas.Find(item.VentaId);
                    venta.Balance = item.Monto - item.Cobrado;
                    contexto.Entry(venta).State = EntityState.Modified;
                }
                contexto.Cobros.Add(cobro);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var cobro = CobrosBLL.Buscar(id);

                if (cobro != null)
                {
                    contexto.Cobros.Remove(cobro);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Cobros Buscar(int id)
        {
            Cobros cobro = new Cobros();
            Contexto contexto = new Contexto();

            try
            {
                cobro = contexto.Cobros.Include(c => c.Detalle)
                    .Where(c => c.CobroId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cobro;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Cobros.Any(c => c.CobroId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
