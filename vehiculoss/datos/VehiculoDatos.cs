using vehiculoss.Models;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace vehiculoss.datos
{
    public class VehiculoDatos
    {
        public List<VehiculoModel> Listar()
        {
            var olista = new List<VehiculoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new VehiculoModel() {
                            IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]),
                            Placa = dr["Placa"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            TipoVehiculo = dr["TipoVehiculo"].ToString(),
                            Cilindraje = dr["Cilindraje"].ToString(),
                            CiudadRegistro = dr["CiudadRegistro"].ToString(),

                        });
                    }
                }
            }
            return olista;
        }
        public VehiculoModel obtener(int IdVehiculo)
        {
            var oVehiculo = new VehiculoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVehiculo", conexion);
                cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                     oVehiculo.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                     oVehiculo.Placa = dr["Placa"].ToString();
                     oVehiculo.Marca = dr["Marca"].ToString();
                     oVehiculo.Modelo = dr["Modelo"].ToString();
                     oVehiculo.Cilindraje = dr["cilindraje"].ToString();
                     oVehiculo.TipoVehiculo = dr["TipoVehiculo"].ToString();
                     oVehiculo.CiudadRegistro = dr["CiudadRegistro"].ToString();

                    }
                }
            }
            return oVehiculo;
        }
        public bool Guardar(VehiculoModel ovehiculo)
        {
            bool rpta;
            try{
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("placa", ovehiculo.Placa);
                    cmd.Parameters.AddWithValue("marca", ovehiculo.Marca);
                    cmd.Parameters.AddWithValue("modelo", ovehiculo.Modelo);
                    cmd.Parameters.AddWithValue("tipoVehiculo", ovehiculo.TipoVehiculo);
                    cmd.Parameters.AddWithValue("cilindraje", ovehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("ciudadRegistro", ovehiculo.CiudadRegistro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error=e.Message;
                rpta = false;

            }
            return rpta;
        }
        public bool Editar(VehiculoModel ovehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", ovehiculo.IdVehiculo);
                    cmd.Parameters.AddWithValue("placa", ovehiculo.Placa);
                    cmd.Parameters.AddWithValue("marca", ovehiculo.Marca);
                    cmd.Parameters.AddWithValue("modelo", ovehiculo.Modelo);
                    cmd.Parameters.AddWithValue("tipoVehiculo", ovehiculo.TipoVehiculo);
                    cmd.Parameters.AddWithValue("cilindraje", ovehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("ciudadRegistro", ovehiculo.CiudadRegistro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }
            return rpta;
        }
        public bool Eliminar(int IdVehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }
            return rpta;
        }


    } 

}
