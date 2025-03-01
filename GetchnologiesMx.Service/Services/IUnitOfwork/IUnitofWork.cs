using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Service.Services.IUnitOfworks
{
    public interface IUnitOfwork : IDisposable
    {
        DbContext Context { get; } 
        public Task SaveChangesAsync(); 
    }
}
