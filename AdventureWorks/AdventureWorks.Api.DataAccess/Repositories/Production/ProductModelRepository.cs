using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductModelRepository: AbstractProductModelRepository, IProductModelRepository
	{
		public ProductModelRepository(
			ILogger<ProductModelRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>6dc14190c686d1bcd204da9137b659e1</Hash>
</Codenesium>*/