using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using  Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Cedulados
{
    public class Consulta
    {
        public class ListaCedula : IRequest<List<Cedulado>> {

            public class Manejador : IRequestHandler<ListaCedula, List<Cedulado>>
            {
                private readonly pruebaContext _context;
                public Manejador(pruebaContext context)
                {

                    _context = context;

                }
                 public async Task<List<Cedulado>> Handle(ListaCedula request, CancellationToken cancellationToken)
                {
                    var cedula = await _context.Cedulados.ToListAsync();
                     return cedula;
                }

         
            }

        }
        
    }
}