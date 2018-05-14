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
	public class ProductDescriptionRepository: AbstractProductDescriptionRepository, IProductDescriptionRepository
	{
		public ProductDescriptionRepository(
			IObjectMapper mapper,
			ILogger<ProductDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b28a6710d2f0cc1f0622f06790381fef</Hash>
</Codenesium>*/