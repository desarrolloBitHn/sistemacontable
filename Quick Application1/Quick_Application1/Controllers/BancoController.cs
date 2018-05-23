using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Quick_Application1.ViewModels;
using AutoMapper;
using DAL.Models;
using DAL.Core.Interfaces;
using Quick_Application1.Authorization;
using Quick_Application1.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using DAL.Core;
using DAL;
using Microsoft.Extensions.Logging;

namespace Quick_Application1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BancoController : Controller
    {

        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        public BancoController(IUnitOfWork unitOfWork, ILogger<BancoController> logger) {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Banco
        [HttpGet("Bancos")]
        [Produces(typeof(IEnumerable<BancosViewModel>))]
        public async Task<IActionResult> GetBancos()
        {
            var allBancos = await _unitOfWork.Bancos.GetBancos();
            return Ok(Mapper.Map<IEnumerable<BancosViewModel>>(allBancos));
        }

        // GET: api/Banco/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Banco
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Banco/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
