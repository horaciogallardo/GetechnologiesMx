using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GetechnologiesMx.Service.Dtos;

namespace GetechnologiesMx.Service.Services.Repository
{
    public class VentasRepository : RepositoryBase<VentasDtos>
    {
        public VentasRepository(IUnitOfwork unitOfwork) : base(unitOfwork)
        { 
        } 
    }
}
