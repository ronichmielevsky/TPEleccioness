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
        ViewBag.listPartido=BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.DatosPartido=BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos=BD.ListarCandidatos(idPartido);
        return View();
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.DatosCandidato=BD.VerInfoCandidato(idCandidato);
        return View();
    }
     public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.idPartido=idPartido;

        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost] public IActionResult GuardarCandidato(Candidato can)
    {
        BD.AgregarCandidato(can);
       return RedirectToAction (HomeController.ReferenceEquals.VerDetallePartido,BD.VerInfoPartido);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
