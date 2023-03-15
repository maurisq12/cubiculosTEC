using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class Reservas : Controller
{

    public string Index(){
        /*
        Models.SQLConexion objetoConexion = new Models.SQLConexion();
        objetoConexion.establecer();
        objetoConexion.llamada();*/
        return "";
        
    }


    //SET: /Cubi/
    public IActionResult misReservaciones(){
        Models.CodigosQR miQR = new CodigosQR();
        string elcodigo64 = miQR.crearCodigo();
        string codigoListo = "data:image/png;charset=utf-8;base64,"+elcodigo64;
        ViewData["Imagen"]= codigoListo;

        //envio de correo con confirmación
        Models.Correos servCorreo = new Correos();
        servCorreo.enviarCorreo(codigoListo);


        return View();
    }

    public string confirmando(){
        Models.Pdfs nuevoPDF = new Pdfs();
        nuevoPDF.crear();
        return "ya lo cree";
    }
    
    public IActionResult Login(){
        return View();
    }

    public IActionResult Registro(){
        return View();
    }


    [HttpPost]
    public string completarRegistro()
    {
        string cedula = Request.Form["cedula"].ToString();
        string carne = Request.Form["carne"].ToString();
        string nombre = Request.Form["nombre"].ToString();
        string primerApellido = Request.Form["cedula"].ToString();
        string segundoApellido = Request.Form["segundoApellido"].ToString();
        string edad = Request.Form["edad"].ToString();
        string fechaNacimiento = Request.Form["fechaNacimiento"].ToString();
        string correo = Request.Form["correo"].ToString();
        string pass = Request.Form["pass"].ToString();
        Console.WriteLine(primerApellido);
        return "El número de cédula es"+primerApellido;
        
    }


}