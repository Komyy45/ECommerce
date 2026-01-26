using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("api/v{apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}