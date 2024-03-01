using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Service.Services.Repository
{
    public class FacturaRepository : RepositoryBase<Factura>
    {
        public FacturaRepository(IUnitOfwork unitOfwork, string ProcedureName) : base(unitOfwork, ProcedureName)
        {
        }
    }
}
