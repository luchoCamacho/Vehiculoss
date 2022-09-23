using Microsoft.AspNetCore.Mvc;
using vehiculoss.datos;
using vehiculoss.Models;

namespace vehiculoss.Controllers
{
    public class MantenedorVehiculoController : Controller
    {
        VehiculoDatos _vehiculoDatos=new VehiculoDatos();
        public IActionResult Listar()
        {
            var olista= _vehiculoDatos.Listar();
            return View(olista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(VehiculoModel oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();  
            var respuesta=_vehiculoDatos.Guardar(oVehiculo);
            if(respuesta)
                return  RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdVehiculo)
        {
            var oVehiculo = _vehiculoDatos.obtener(IdVehiculo);
            return View(oVehiculo);
        }
        [HttpPost]
        public IActionResult Editar(VehiculoModel oVehiculo)
         {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _vehiculoDatos.Editar(oVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int IdVehiculo)
        {
            var oVehiculo = _vehiculoDatos.obtener(IdVehiculo);
            return View(oVehiculo);
        }
        [HttpPost]
        public IActionResult Eliminar(VehiculoModel oVehiculo)
        {
           
            var respuesta = _vehiculoDatos.Eliminar(oVehiculo.IdVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
