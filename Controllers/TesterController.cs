using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;
using project.Repository;
using project.Repository.Interfaces;
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
        private readonly IRoleRepository _repo;

        public TesterController(ILogger<TesterController> logger, IRoleRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ApplicationUser user, string roleName)
        {
            try
            {
                //await _repo.RemoveFromRoleAsync(user, roleName);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetBy")]
        public async Task<IActionResult> GetBy(string id)
        {
            try
            {
                return Ok(await _repo.FindByNameAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ApplicationRole role)
        {
            try
            {
                await _repo.CreateAsync(role);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ApplicationRole role)
        {
            try
            {
                await _repo.UpdateAsync(role);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ApplicationRole user)
        {
            try
            {
                return Ok(await _repo.DeleteAsync(user));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
