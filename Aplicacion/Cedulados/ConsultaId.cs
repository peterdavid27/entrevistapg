using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using  Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Cedulados
{
    public class ConsultaId
    {
        public class CedulaUnica : IRequest<Cedulado> {
            public int Id {get ; set;}
        }
        
        public class Manejador : IRequestHandler<CedulaUnica, Cedulado>
        {
            private readonly pruebaContext _context;
            public Manejador(pruebaContext context)
            {
                _context = context;
            }

            public async Task<Cedulado> Handle(CedulaUnica request, CancellationToken cancellationToken)
            {
               var cedulaid = await _context.Cedulados.FindAsync(request.Id);
               return cedulaid;
            }
        }
    }
}