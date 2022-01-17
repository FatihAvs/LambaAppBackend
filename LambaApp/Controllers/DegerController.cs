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
    public class DegerController : CustomBaseController
    {
        private readonly IServiceGeneric<Deger> _serviceGeneric;
        public DegerController(IServiceGeneric<Deger> serviceGeneric)
        {
            _serviceGeneric = serviceGeneric;
        }
        [HttpPut]
        public IActionResult DegerDurumunuGuncelle(Deger deger)
        {
            return ActionResultInstance(_serviceGeneric.Update(deger));
        }
        [HttpGet]
        public async Task<IActionResult> getById()
        {
            var id = 1;
            return ActionResultInstance(await _serviceGeneric.GetByIdAsync(id));
        }
    }
}
