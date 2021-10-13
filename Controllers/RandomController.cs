using Baraja_PilarMontenegro.Data;
using Baraja_PilarMontenegro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baraja_PilarMontenegro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RandomController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]

        public async Task<ActionResult<Naipe>> GetNaipe()
        {
            var list = await _context.Naipe.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);

            var carta = list[index];

            if (carta == null)
            {
                return NoContent();
            }
            return carta;
        }


    }
}
