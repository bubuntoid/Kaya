using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Kaya.Service.WebAPI.Controllers.External;

[ApiController]
public class IndexController : ControllerBase
{
    public IndexController()
    {
        
    }

    [Route(""), HttpGet]
    public Task<IActionResult> Index()
    {
        return StaticFile("index.html");
    }
    
    [HttpGet("{fileName}")]
    public async Task<IActionResult> StaticFile(string fileName)
    {
        var content = await System.IO.File.ReadAllTextAsync($@"./Frontend/{fileName}");
        new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);
        return Content(content, contentType!);
    }
}