using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPElecciones.Models;

namespace TPElecciones.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.listPartido = BD.ListarPartidos();
        
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View();
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.DatosCandidato = BD.VerInfoCandidato(idCandidato);
        return View();
    }
    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.idPartido = idPartido;

        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(int idCandidato, int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion)
    {
        Candidato can = new Candidato(idCandidato,idPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion);
        BD.AgregarCandidato(can);
        ViewBag.DatosPartido = BD.VerInfoPartido(can.idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(can.idPartido);
        return View("VerDetallePartido");
    }


    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }

    public IActionResult Elecciones()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
