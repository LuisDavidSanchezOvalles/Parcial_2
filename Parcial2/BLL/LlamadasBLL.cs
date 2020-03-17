using System;
using System.Collections.Generic;
using System.Text;
using Parcial2.Entidades;
using Parcial2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Parcial2.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Llamadas.Add(llamada) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM LlamadaDetalle Where LlamadaId = {llamada.LlamadaId}");

                foreach(var item in llamada.LlamadasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(llamada).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamada Buscar(int id)
        {
            Llamada llamada = new Llamada();
            Contexto db = new Contexto();

            try
            {
                llamada = db.Llamadas.Include(l => l.LlamadasDetalle).Where(l => l.LlamadaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamada;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = LlamadasBLL.Buscar(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static List<Llamada> GetList(Expression<Func<Llamada, bool>> llamada)
        {
            List<Llamada> Lista = new List<Llamada>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Llamadas.Where(llamada).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
