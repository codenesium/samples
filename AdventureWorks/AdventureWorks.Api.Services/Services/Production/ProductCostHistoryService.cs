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
    <Hash>8e8ef7b331d7853b014d56d81ffc7028</Hash>
</Codenesium>*/