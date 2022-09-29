
using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Aplicacion.Cedulados;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CedulasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CedulasController(IMediator meditor){
            _mediator = meditor;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cedulado>>> Get(){

            return await _mediator.Send(new Consulta.ListaCedula());
        }


    [HttpGet("{id}")]
    public async Task<ActionResult<Cedulado>> Detalle(int id){
        return await _mediator.Send(new ConsultaId.CedulaUnica{Id = id});
    }
    }   

    
}