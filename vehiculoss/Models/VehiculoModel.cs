using System.ComponentModel.DataAnnotations;

namespace vehiculoss.Models
{
    public class VehiculoModel
    {
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "el campo Placa es obligatorio")]
        public string? Placa { get; set; }
        [Required(ErrorMessage ="el campo Marca es obligatorio")]
        public string?  Marca { get; set; }
        [Required(ErrorMessage = "el campo Modelo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "el campo Cilindraje es obligatorio")]
        public string? Cilindraje { get; set; }
        [Required(ErrorMessage = "el campo Tipo de Vehiculo es obligatorio")]
        public string? TipoVehiculo { get; set; }
        [Required(ErrorMessage = "el campo Ciudad de registro es obligatorio")]
        public string? CiudadRegistro { get; set; }
        


    }
}
