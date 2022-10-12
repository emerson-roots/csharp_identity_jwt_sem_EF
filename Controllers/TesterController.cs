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
        private readonly IUserRepository _repo;

        public TesterController(ILogger<TesterController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ApplicationUser user, string roleName)
        {
            try
            {
                await _repo.RemoveFromRoleAsync(user, roleName);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetBy")]
        public async Task<IActionResult> GetBy(int id)
        {
            try
            {
                return Ok(await _repo.FindByIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ApplicationUser user)
        {
            try
            {
                await _repo.UpdateAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ApplicationUser user)
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
