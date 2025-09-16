using cp4_GeoMasterAPI.Entities;
using cp4_GeoMasterAPI.Validacoes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cp4_GeoMasterAPI.Controllers
{
    [ApiController]
    [Route("api/v1/validacoes")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public class ValidacoesController : ControllerBase
    {
        private readonly IValidacaoContencaoService _svc;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            Converters = { new Forma2DJsonConverter() }
        };

        public ValidacoesController(IValidacaoContencaoService svc) => _svc = svc;

        /// <summary>
        /// Verifica se uma forma está contida dentro de outra
        /// </summary>
        /// <remarks>
        /// Retorna um valor booleano.
        /// </remarks>
        /// <returns>True se a forma interna estiver contida, False caso contrário</returns>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult FormaContida([FromBody] ContencaoRequest req)
        {
            if (req is null) return BadRequest("Body obrigatório.");
            try
            {
                var outer = JsonSerializer.Deserialize<object>(req.FormaExterna.GetRawText(), _jsonOptions)!;
                var inner = JsonSerializer.Deserialize<object>(req.FormaInterna.GetRawText(), _jsonOptions)!;

                var result = _svc.EstaContida(outer, inner);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // --- DTOs/Converter polimórfico 2D básicos ---

        public class ContencaoRequest
        {
            [Required] public JsonElement FormaExterna { get; set; }
            [Required] public JsonElement FormaInterna { get; set; }
        }

        public class Forma2DJsonConverter : JsonConverter<object>
        {
            public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(object);

            public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                if (!doc.RootElement.TryGetProperty("tipo", out var tipoProp))
                    throw new JsonException("Campo 'tipo' é obrigatório.");

                var tipo = tipoProp.GetString()?.ToLowerInvariant();
                return tipo switch
                {
                    "circulo" => doc.RootElement.Deserialize<Circulo>(options)!,
                    "retangulo" => doc.RootElement.Deserialize<Retangulo>(options)!,
                    // Você pode expandir com 3D usando outro converter/rota
                    _ => throw new JsonException($"Tipo desconhecido: {tipo}")
                };
            }

            public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
                => JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
