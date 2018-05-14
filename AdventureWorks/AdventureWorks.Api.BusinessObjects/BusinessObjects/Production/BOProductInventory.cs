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
			IApiProductInventoryModelValidator productInventoryModelValidator)
			: base(logger, productInventoryRepository, productInventoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9842784451e024c3669a6dc7dcf9c213</Hash>
</Codenesium>*/