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
			IProductModelValidator productModelValidator)
			: base(logger, productRepository, productModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6ebd02b8cf4a69d56fad682dbce6686c</Hash>
</Codenesium>*/