using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;

namespace CubiculosTEC.Controllers;

public class Reservas : Controller
{

    public IActionResult Index(){
        return View();
        
    }

    //SET: /Cubi/
    public IActionResult misReservaciones(){
        


        

        return View();
    }

    public void confirmando(){
        Models.CodigosQR miQR = new CodigosQR();
        string elcodigo64 = miQR.crearCodigo();
        string codigoListo = "data:image/png;charset=utf-8;base64,"+elcodigo64;
        ViewData["Imagen"]= codigoListo;
        Models.Pdfs nuevoPDF = new Pdfs();
        nuevoPDF.crear();
        
        //envio de correo con confirmación
        Models.Correos servCorreo = new Correos();
        servCorreo.enviarCorreo(codigoListo);
    }

}