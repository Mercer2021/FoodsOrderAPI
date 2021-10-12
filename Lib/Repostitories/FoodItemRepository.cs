using Lib.Data;
using Lib.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Repostitories
{
    public interface IFoodItemRepository : IGenericRepository<FoodItem>
    {

    }
    public class FoodItemRepository : GenericRepository<FoodItem>,IFoodItemRepository
    {
        public FoodItemRepository(FoodsOrderAPIContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
