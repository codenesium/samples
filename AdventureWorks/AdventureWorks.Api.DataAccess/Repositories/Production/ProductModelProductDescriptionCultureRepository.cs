using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductModelProductDescriptionCultureRepository: AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
	{
		public ProductModelProductDescriptionCultureRepository(
			ILogger<ProductModelProductDescriptionCultureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3f5ebe5dd17a3c0406e0d34a08f49f03</Hash>
</Codenesium>*/