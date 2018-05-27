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
	public class ProductModelProductDescriptionCultureRepository: AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
	{
		public ProductModelProductDescriptionCultureRepository(
			IDALProductModelProductDescriptionCultureMapper mapper,
			ILogger<ProductModelProductDescriptionCultureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a5957d3a818c5f936e9af73c990e6ee8</Hash>
</Codenesium>*/