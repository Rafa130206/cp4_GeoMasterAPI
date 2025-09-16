using cp4_GeoMasterAPI.DTOs;
using cp4_GeoMasterAPI.Entities;
using cp4_GeoMasterAPI.Interfaces;
using cp4_GeoMasterAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace cp4_GeoMasterAPI.Controller
{
    [Route("api/calculos")]
    [ApiController]
    public class CalculosController : ControllerBase
    {

        private readonly ICalculadoraService _service;

        public CalculosController(ICalculadoraService service)
        {
            _service = service;
        }

        [HttpPost("area")]
        public IActionResult CalcularArea([FromBody] FormaDTO formaDto)
        {

            ICalculos2D forma = formaDto.TipoForma.ToLower() switch
            {
                "circulo" => new Circulo { Raio = formaDto.Propriedades["raio"] },
                "retangulo" => new Retangulo { Largura = formaDto.Propriedades["largura"], Altura = formaDto.Propriedades["altura"] },
                _ => null
            };

            foreach (var valor in formaDto.Propriedades.Values)
            {
                if ( valor < 0)
                {
                    return BadRequest("Valores não podem ser negativos");
                }
            }

            if (forma == null)
            {
                return BadRequest("Tipo de forma não suportado");
            }
            

                double resultado = _service.CalcularArea(forma);
                 return Ok(new { area = resultado });
        }

        [HttpPost("perimetro")]
        public IActionResult CalcularPerimetro([FromBody] FormaDTO formaDto)
        {
            ICalculos2D forma = formaDto.TipoForma.ToLower() switch
            {
                "circulo" => new Circulo { Raio = formaDto.Propriedades["raio"] },
                "retangulo" => new Retangulo { Largura = formaDto.Propriedades["largura"], Altura = formaDto.Propriedades["altura"] },
                _ => null
            };

            foreach (var valor in formaDto.Propriedades.Values)
            {
                if (valor < 0)
                {
                    return BadRequest("Valores não podem ser negativos");
                }
            }

            if (forma == null)
            {
                return BadRequest("Tipo de forma não suportado");
            }

            double resultado = _service.CalcularPerimetro(forma);
            return Ok(new { perimetro = resultado });
        }

        [HttpPost("volume")]
        public IActionResult CalcularVolume([FromBody] FormaDTO formaDto)
        {
            ICalculos3D forma = formaDto.TipoForma.ToLower() switch
            {
                "esfera" => new Esfera { Raio = formaDto.Propriedades["raio"] },
                _ => null
            };

            foreach (var valor in formaDto.Propriedades.Values)
            {
                if (valor < 0)
                {
                    return BadRequest("Valores não podem ser negativos");
                }
            }

            if (forma == null)
            {
                return BadRequest("Tipo de forma não suportado");
            }

            double resultado = _service.CalcularVolume(forma);
            return Ok(new { volume = resultado });
        }

        [HttpPost("areaSuperficial")]
        public IActionResult CalcularAreaSuperficial([FromBody] FormaDTO formaDto)
        {
            ICalculos3D forma = formaDto.TipoForma.ToLower() switch
            {
                "esfera" => new Esfera { Raio = formaDto.Propriedades["raio"] },
                _ => null
            };

            foreach (var valor in formaDto.Propriedades.Values)
            {
                if (valor < 0)
                {
                    return BadRequest("Valores não podem ser negativos");
                }
            }

            if (forma == null)
            {
                return BadRequest("Tipo de forma não suportado");
            }

            double resultado = _service.CalcularAreaSuperficial(forma);
            return Ok(new { areaSuperficial = resultado });
        }

    }
}
