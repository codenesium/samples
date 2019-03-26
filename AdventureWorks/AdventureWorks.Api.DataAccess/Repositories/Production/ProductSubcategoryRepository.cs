using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductSubcategoryRepository : AbstractProductSubcategoryRepository, IProductSubcategoryRepository
	{
		public ProductSubcategoryRepository(
			ILogger<ProductSubcategoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42d8e335f6460fe8a8460f79f472f347</Hash>
</Codenesium>*/