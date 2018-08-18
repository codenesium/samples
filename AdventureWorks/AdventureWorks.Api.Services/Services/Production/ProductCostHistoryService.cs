using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductCostHistoryService : AbstractProductCostHistoryService, IProductCostHistoryService
	{
		public ProductCostHistoryService(
			ILogger<IProductCostHistoryRepository> logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper bolproductCostHistoryMapper,
			IDALProductCostHistoryMapper dalproductCostHistoryMapper
			)
			: base(logger,
			       productCostHistoryRepository,
			       productCostHistoryModelValidator,
			       bolproductCostHistoryMapper,
			       dalproductCostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6ae60c9616b1f2808eb2db14859c87b</Hash>
</Codenesium>*/