using CubiculosTEC.Models;
using System.Data;
using System.Data.SqlClient;


namespace CubiculosTEC.Logica;

public class LO_Usuario{
    public Usuario encontrarUsuario(string pCorreo, string pContrasena){
        Usuario objeto = new Usuario();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT Nombre, correo,contrasena,rol FROM Usuarios WHERE correo=@pCorreo and contrasena = @pContrasena";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pCorreo",pCorreo);
        cmd.Parameters.AddWithValue("@pContrasena",pContrasena);

        if (conectado.State != ConnectionState.Open){

            conectado.Close();
            conectado.Open();
        }
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                objeto = new Usuario(){
                    nombre= dr["Nombre"].ToString()
                    
                };
            }
        }
        return objeto;  
    }


    public bool verificarCorreo(string pCorreo){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();
        string query= "SELECT Nombre, correo,contrasena,rol FROM Usuarios WHERE correo=@pCorreo";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pCorreo",pCorreo);

        if (conectado.State != ConnectionState.Open){

            conectado.Close();
            conectado.Open();
        }
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                if(dr["Nombre"]!=null){
                    return false;
                }                
            }
            return true;
        }
    }


    public bool nuevoUsuario(Registro pUsuario){
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();
        string query= "sp";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pCedula",pUsuario.cedula);
        cmd.Parameters.AddWithValue("@pCarne",pUsuario.carne);
        cmd.Parameters.AddWithValue("@pNombre",pUsuario.nombre);
        cmd.Parameters.AddWithValue("@pApellido1",pUsuario.apellido1);
        cmd.Parameters.AddWithValue("@pApellido2",pUsuario.apellido2);
        cmd.Parameters.AddWithValue("@pEdad",pUsuario.edad);
        cmd.Parameters.AddWithValue("@pFecha",pUsuario.fechaNacimiento);
        cmd.Parameters.AddWithValue("@pCorreo",pUsuario.correo);
        cmd.Parameters.AddWithValue("@pContrasena",pUsuario.contrasena);


        if (conectado.State != ConnectionState.Open){
            conectado.Close();
            conectado.Open();
        }
        using (SqlDataReader dr = cmd.ExecuteReader()){
            return true;
        }
    }
}

    
