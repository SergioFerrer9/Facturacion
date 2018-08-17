using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facturacion.Models;
using System.Data.SqlClient;
using System.Data;
using Facturacion.DAO;


namespace Facturacion.Controllers
{
    public class FacturaController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Listar Clientes.
        /// </summary>
        /// <returns>Retorna una lista en en JSON</returns>
        public ActionResult ListarCliente() 
        {
            try 
            { 
                Conexion conexion = new Conexion();
                List<Factura> factura = conexion.ListarCliente2();
                return Json(factura, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListarProducto()
        {
            try
            {
                Conexion conexion = new Conexion();
                List<Producto> factura = conexion.ListarProducto();
                return Json(factura, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        
        
    }
}
