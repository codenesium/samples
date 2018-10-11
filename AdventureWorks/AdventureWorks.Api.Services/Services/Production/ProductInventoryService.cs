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
	public partial class ProductInventoryService : AbstractProductInventoryService, IProductInventoryService
	{
		public ProductInventoryService(
			ILogger<IProductInventoryRepository> logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper bolproductInventoryMapper,
			IDALProductInventoryMapper dalproductInventoryMapper)
			: base(logger,
			       productInventoryRepository,
			       productInventoryModelValidator,
			       bolproductInventoryMapper,
			       dalproductInventoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dd90c1d61bdc30b6ca73de443b6403e6</Hash>
</Codenesium>*/