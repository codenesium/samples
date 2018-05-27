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
			IDALProductDescriptionMapper mapper,
			ILogger<ProductDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3ba45349b3dbf7488569f19bc8fd505a</Hash>
</Codenesium>*/