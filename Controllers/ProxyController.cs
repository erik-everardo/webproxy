using System.Text.Json.Nodes;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace webproxy.Controllers;

[ApiController]
[Route("[controller]")]
public class ProxyController : ControllerBase
{
    private readonly ILogger _logger;

    public ProxyController(ILogger<ProxyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Get")]
    public IActionResult Get(string url)
    {
        var httpClient = new HttpClient();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;
        var response = httpClient.Send(request);
        var responseStream = response.Content.ReadAsStream();
        try {
            var parsed = JsonNode.Parse(responseStream);
            return Ok(parsed.AsObject());
        } catch(JsonException){
            return Ok("Error parseando");
        }
        
    }
}
