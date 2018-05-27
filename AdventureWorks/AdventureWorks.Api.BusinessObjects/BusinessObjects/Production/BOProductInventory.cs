using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductInventory: AbstractBOProductInventory, IBOProductInventory
	{
		public BOProductInventory(
			ILogger<ProductInventoryRepository> logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper productInventoryMapper)
			: base(logger, productInventoryRepository, productInventoryModelValidator, productInventoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b8ed12f82cdfed805ddc6535b1d2a428</Hash>
</Codenesium>*/