using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductDescriptionRepository: AbstractProductDescriptionRepository, IProductDescriptionRepository
	{
		public ProductDescriptionRepository(
			ILogger<ProductDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3f0e6ebe3acf4908420c8d11a0d0c375</Hash>
</Codenesium>*/