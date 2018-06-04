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
        private readonly IAuthorizationService _authorizationService;

        public BancoController(IUnitOfWork unitOfWork, ILogger<BancoController> logger, IAuthorizationService authorizationService) {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _authorizationService = authorizationService;
        }

        // GET: api/Banco/Bancos
        [HttpGet("Bancos")]
        [Produces(typeof(IEnumerable<BancosViewModel>))]
        [Authorize(Authorization.Policies.ViewAllBanksPolicy)]
        public async Task<IActionResult> GetBancos()
        {
            var allBancos = await _unitOfWork.Bancos.GetBancos();
            return Ok(Mapper.Map<IEnumerable<BancosViewModel>>(allBancos));
        }

        // GET: api/Banco/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetBancoById(int id)
        {
            bancos banco = await _unitOfWork.Bancos.GetBancoById(id);
            return Ok(Mapper.Map<BancosViewModel>(banco));
        }
        
        // POST: api/Banco
        [HttpPost]
        [Authorize(Authorization.Policies.ManageAllBankssPolicy)]
        public async Task<IActionResult> PostAgregarBanco([FromBody]bancos _banco)
        {
            var result = await _unitOfWork.Bancos.PostBancos(_banco);
            if (result.Item1)
            {
                return Ok(Mapper.Map<BancosViewModel>(result.Item2));
            }
            else {
                return null;
            }
        }
        
        // PUT: api/Banco/actualizar/5
        [HttpPut("actualizar/{id}")]
        [Authorize(Authorization.Policies.ManageAllBankssPolicy)]
        public async Task<IActionResult> PutActualizarBanco(int id , [FromBody]bancos _banco)
        {
            var result = await _unitOfWork.Bancos.PutActualizarBanco(_banco);
            if (result.Item1)
            {
                return Ok(Mapper.Map<BancosViewModel>(result.Item2));
            }
            else
            {
                return NotFound(id);
            }
        }

        // PUT: api/Banco/borrar/5
        [HttpPut("borrar/{id}")]
        [Authorize(Authorization.Policies.ManageAllBankssPolicy)]
        public async Task<IActionResult> PutBorrarrBanco(int id, [FromBody]int _banco)
        {
            var result = await _unitOfWork.Bancos.DeleteBancos(_banco);
            if (result.Item1)
            {
                return Ok(result.Item2);
            }
            else
            {
                return NotFound(id);
            }
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void DeleteBanco(int id)
        //{
        //}
    }
}
