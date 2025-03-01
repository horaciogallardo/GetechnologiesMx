using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GetechnologiesMx.Service.DataContext;
using GetechnologiesMx.Service.Services.IUnitOfworks;

namespace GetechnologiesMx.Service.Services.UnitofWorkService
{
    public class UnitofWorkService : IUnitOfwork
    {
        private readonly ApiDbContext _context;
        private bool _disposed = false;

        public UnitofWorkService(ApiDbContext context)
        {
            _context = context; 
        }
        public DbContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
