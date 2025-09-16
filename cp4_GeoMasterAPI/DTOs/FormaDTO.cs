using System.ComponentModel.DataAnnotations;

namespace cp4_GeoMasterAPI.DTOs
{
    public class FormaDTO
    {
        [Required(ErrorMessage = "O tipo da forma é obrigatório")]
        public string TipoForma { get; set; }

        [Required(ErrorMessage = "As propriedades da forma  são obrigatórias")]

        public Dictionary<string, double> Propriedades { get; set; }
    }
}
