using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Domain.Models;

namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReaderController:ControllerBase
  {
    private readonly RDTRepo _repo;
    public ReaderController(RDTRepo repository)
    {
      _repo = repository;
    }

    [HttpPost("CreateReader")]
    public async Task<IActionResult> CreateReader (Reader reader)
    {
      if(!_repo.CheckIfReaderExists(reader))
      {
        _repo.CreateReader(reader);
        return await Task.FromResult(Ok());
      }
      else
      {
        return await Task.FromResult(BadRequest("User Already Exists"));
      }

    }


    [HttpGet("ReaderExists")]
    public async Task<IActionResult> CheckIfReaderExists(Reader reader)
    {
      var r =_repo.CheckIfReaderExists(reader);
      return await Task.FromResult(Ok(r));
    }
  }
}
