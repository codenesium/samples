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
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper productMapper)
			: base(logger, productRepository, productModelValidator, productMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>53d31de5c601117a3742b26a135f65c1</Hash>
</Codenesium>*/