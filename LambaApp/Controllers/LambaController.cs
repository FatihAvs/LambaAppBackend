using LambaApp.Entities;
using LambaApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambaApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LambaController : CustomBaseController
    {
        private readonly IServiceGeneric<Lamba> _serviceGeneric;
        public LambaController(IServiceGeneric<Lamba> serviceGeneric)
        {
            _serviceGeneric = serviceGeneric;
        }
        [HttpPut]
        public IActionResult LambaDurumunuGuncelle(Lamba lamba)
        {
            return ActionResultInstance( _serviceGeneric.Update(lamba));
        }
        [HttpGet]
        public async Task<IActionResult> getById()
        {
            var id = 1;
            return  ActionResultInstance(await _serviceGeneric.GetByIdAsync(id));
        }
    }
}
