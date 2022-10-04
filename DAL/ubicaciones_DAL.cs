using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;
namespace DAL
{
    public class ubicaciones_DAL
    {
        SQLDBHELPER oConexion;
        //aqui iniciamos la conexion con la bd usando un constructor
        public ubicaciones_DAL() {
            oConexion = new SQLDBHELPER();
        
        }
        public bool Agregar(ubicaciones_BLL oUbicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);

        }
        public void Modificar() { }
        public void Borrar() { }

        //hacer una consulta para ver los objetos de la bd
        public DataTable Listar() {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Direcciones"; //query para ver todos los elementos de la tabla direcciones

            //Tipo de comando, puede ser texto, sp, etc
            cmdComando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdComando);

            return TablaResultante;
        }
    }
}
