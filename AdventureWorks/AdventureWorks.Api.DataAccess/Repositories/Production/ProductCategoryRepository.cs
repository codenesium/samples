using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductCategoryRepository: AbstractProductCategoryRepository, IProductCategoryRepository
	{
		public ProductCategoryRepository(
			IDALProductCategoryMapper mapper,
			ILogger<ProductCategoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a35fb0068b431f924355b68f83b2a135</Hash>
</Codenesium>*/