using Full_Stack_Mercury_Maps.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ClientRepository _userRepo;
    private ClientRepository _clientRepo;

    public ClientsController(ClientRepository clientRepo)
    {
        _clientRepo = clientRepo;
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
        var client = _userRepo.GetClientById(id);
        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    // POST: api/Clients
    [HttpPost]
    public ActionResult<Client> Post(Client client)
    {
        _userRepo.AddClient(client);
        return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
    }

    // PUT: api/Clients/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _userRepo.UpdateClient(client);

        return NoContent();
    }

    // DELETE: api/Clients/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userRepo.DeleteClient(id);
        return NoContent();
    }
}
