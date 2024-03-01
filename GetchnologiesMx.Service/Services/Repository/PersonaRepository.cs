using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Service.Services.Repository
{
    public class PersonaRepository : RepositoryBase<Factura>
    {
        public PersonaRepository(IUnitOfwork unitOfwork, string ProcedureName) : base(unitOfwork, ProcedureName)
        {

        }
    }
}
