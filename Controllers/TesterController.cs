using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesterController : ControllerBase
    {

        private readonly ILogger<TesterController> _logger;
        private readonly UserRepository _repo;

        public TesterController(ILogger<TesterController> logger, UserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            try
            {
                return await _repo.GetAllUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
