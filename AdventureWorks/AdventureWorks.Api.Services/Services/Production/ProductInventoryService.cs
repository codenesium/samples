using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductInventoryService: AbstractProductInventoryService, IProductInventoryService
	{
		public ProductInventoryService(
			ILogger<ProductInventoryRepository> logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper BOLproductInventoryMapper,
			IDALProductInventoryMapper DALproductInventoryMapper)
			: base(logger, productInventoryRepository,
			       productInventoryModelValidator,
			       BOLproductInventoryMapper,
			       DALproductInventoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>af4276b7912fe168eb7ee07abef9e880</Hash>
</Codenesium>*/