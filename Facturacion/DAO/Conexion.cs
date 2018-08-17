using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Facturacion.Models;
using System.Data;


namespace Facturacion.DAO
{
   
    public class Conexion
    {
        public List<Factura> ListarCliente()
        {
            ///Cdena de Conexion a la base de datos ModuloFactura.
            String _conexionCliente = "Data Source=FISICA\\SQLEXPRESS; Initial Catalog=ModuloFactura; Integrated Security=true;";
            String sqlConsuta = "spr_Clientes";
            List<Factura> listaFactura = new List<Factura>();
            try
            {
                SqlConnection sqlConexion = new SqlConnection(_conexionCliente);
                SqlCommand consulta = new SqlCommand(sqlConsuta, sqlConexion);
                sqlConexion.Open();
                using (var interador = consulta.ExecuteReader())
                {
                    while (interador.Read())
                    {
                        Factura factura = new Factura();
                        factura.idCliente = Convert.ToInt32(interador["idCliente"]);
                        factura.nombreCliente = Convert.ToString(interador["nombre"]);
                        factura.nit = Convert.ToInt32(interador["nit"]);
                        listaFactura.Add(factura);
                    }
                }
                return listaFactura;
            }
            catch (SqlException s)
            {

                throw s;
            }

        }

        public List<Factura> ListarCliente2()
        {
            ///Cdena de Conexion a la base de datos ModuloFactura.
            String _conexionCliente = "Data Source=FISICA\\SQLEXPRESS; Initial Catalog=ModuloFactura; Integrated Security=true;";
            String sqlConsuta = "spr_Clientes";
            List<Factura> listaFactura = new List<Factura>();
            using( SqlConnection sqlConexion = new SqlConnection(_conexionCliente))
            {
                SqlTransaction transaccion = null;
                try
                {
                    sqlConexion.Open();
                    transaccion = sqlConexion.BeginTransaction("Transaccion");
                    var consulta = new SqlCommand(sqlConsuta, sqlConexion,transaccion);
                    consulta.CommandType = CommandType.StoredProcedure;
                    consulta.ExecuteNonQuery();
                    using (var interador = consulta.ExecuteReader())
                    {
                        while (interador.Read())
                        {
                            Factura factura = new Factura();
                            factura.idCliente = Convert.ToInt32(interador["idCliente"]);
                            factura.nombreCliente = Convert.ToString(interador["nombre"]);
                            factura.nit = Convert.ToInt32(interador["nit"]);
                            listaFactura.Add(factura);
                        }
                    }
                    transaccion.Commit();
                    return listaFactura;
                }
                catch(SqlException e)
                {
                    transaccion.Rollback();
                    throw new Exception(e.Message);
                }
            }      

        }

        public List<Producto> ListarProducto()
        {
            ///Cdena de Conexion a la base de datos ModuloFactura.
            String _conexionCliente = "Data Source=FISICA\\SQLEXPRESS; Initial Catalog=ModuloFactura; Integrated Security=true;";
            String sqlConsuta = "spr_Productos";
            List<Producto> listaFactura = new List<Producto>();
            using (SqlConnection sqlConexion = new SqlConnection(_conexionCliente))
            {
                SqlTransaction transaccion = null;
                try
                {
                    sqlConexion.Open();
                    transaccion = sqlConexion.BeginTransaction("Transaccion2");
                    var consulta = new SqlCommand(sqlConsuta, sqlConexion, transaccion);
                    consulta.CommandType = CommandType.StoredProcedure;
                    consulta.ExecuteNonQuery();
                    using (var interador = consulta.ExecuteReader())
                    {
                        while (interador.Read())
                        {
                            Producto factura = new Producto();
                            factura.idProducto = Convert.ToInt32(interador["idProducto"]);
                            factura.nombreProducto = Convert.ToString(interador["nombreProducto"]);
                            factura.precio = Convert.ToInt32(interador["precio"]);
                            listaFactura.Add(factura);
                        }
                    }
                    transaccion.Commit();
                    return listaFactura;
                }
                catch (SqlException e)
                {
                    transaccion.Rollback();
                    throw new Exception(e.Message);
                }
            }

        }


    }
}