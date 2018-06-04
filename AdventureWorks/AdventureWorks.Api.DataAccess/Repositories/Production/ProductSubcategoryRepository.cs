using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductSubcategoryRepository: AbstractProductSubcategoryRepository, IProductSubcategoryRepository
	{
		public ProductSubcategoryRepository(
			ILogger<ProductSubcategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8705b0783be14ffaf636d6bebde0d9ad</Hash>
</Codenesium>*/