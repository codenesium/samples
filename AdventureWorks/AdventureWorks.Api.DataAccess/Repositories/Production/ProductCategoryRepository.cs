using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductCategoryRepository: AbstractProductCategoryRepository, IProductCategoryRepository
	{
		public ProductCategoryRepository(
			ILogger<ProductCategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3414a892272793c7d73814b06fed4566</Hash>
</Codenesium>*/