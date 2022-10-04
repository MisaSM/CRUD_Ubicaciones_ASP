﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//capas
using BLL;
using DAL;  

namespace CrudUbicaciones_MSM_TIDSM4A
{
    public partial class formUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicaciones_DAL oUbicacionesDal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ListarUbicaciones();
            }
        }

        //Metodo encargado de listar los datos en un GridView
        public void ListarUbicaciones() 
        {
            oUbicacionesDal = new ubicaciones_DAL();
            gvUbicaciones.DataSource = oUbicacionesDal.Listar();
            gvUbicaciones.DataBind();
        }
        //Metodo encargado de recolectar los datos de nuestra interfaz
        public ubicaciones_BLL datosUbicacion() 
        {
            int ID = 0;
            int.TryParse(txtIDn.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();
            
            //Recolectar datos de la capa de presentacion
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;

        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDal = new ubicaciones_DAL();
            oUbicacionesDal.Agregar(datosUbicacion());
            ListarUbicaciones();
        }
    }
}