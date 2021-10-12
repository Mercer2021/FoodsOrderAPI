using Lib.Repostitories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public interface IUnitOfWork
    {
        IFoodItemRepository FoodItems { get; }
        Task CompleteAsync();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FoodsOrderAPIContext _context { get; set; }
        private readonly ILogger _logger;

        public IFoodItemRepository FoodItems { get; private set; }

        public UnitOfWork(FoodsOrderAPIContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            FoodItems = new FoodItemRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
