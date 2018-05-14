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
	public class BOProduct: AbstractBOProduct, IBOProduct
	{
		public BOProduct(
			ILogger<ProductRepository> logger,
			IProductRepository productRepository,
			IApiProductModelValidator productModelValidator)
			: base(logger, productRepository, productModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>660de3207a4ea81ddf7b71259d5566b8</Hash>
</Codenesium>*/