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
			IDALProductModelMapper mapper,
			ILogger<ProductModelRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8255d99e19dca611b7dc19177004bf93</Hash>
</Codenesium>*/