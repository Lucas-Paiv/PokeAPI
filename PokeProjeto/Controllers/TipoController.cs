using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeProjeto.Data;
using PokeProjeto.Models;

namespace PokeProjeto.Controllers
{   
    [Controller]
    [Route("[controller]")]
    public class TipoController : ControllerBase
    {
        private DataContext dc;

        public TipoController(DataContext context){
            this.dc = context;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> cadastrar([FromBody] Tipo tipo){
            dc.t.Add(tipo);
            await dc.SaveChangesAsync();
            return Created("Objeto tipo", tipo);
        }

        [HttpGet("listar")]
        public async Task<ActionResult> listar(){
            var dados = await dc.t.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("listar/{id}")]
        public Tipo filtrar(int id){
            Tipo type = dc.t.Find(id);
            return type;
        }
    }
}