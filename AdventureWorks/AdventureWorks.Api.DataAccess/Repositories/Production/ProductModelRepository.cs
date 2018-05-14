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
	public class ProductModelRepository: AbstractProductModelRepository, IProductModelRepository
	{
		public ProductModelRepository(
			IObjectMapper mapper,
			ILogger<ProductModelRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8f6d0d2af331ab7c092fc09ff02a5a28</Hash>
</Codenesium>*/