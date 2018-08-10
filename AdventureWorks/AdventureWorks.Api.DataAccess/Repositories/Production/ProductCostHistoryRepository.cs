using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductCostHistoryRepository : AbstractProductCostHistoryRepository, IProductCostHistoryRepository
	{
		public ProductCostHistoryRepository(
			ILogger<ProductCostHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>29a23754af9534ff3e564ab18c8447cf</Hash>
</Codenesium>*/