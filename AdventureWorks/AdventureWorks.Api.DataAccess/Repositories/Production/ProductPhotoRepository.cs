using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductPhotoRepository: AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(
			ILogger<ProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>5f6f235fe57f794998431ec41f3fba05</Hash>
</Codenesium>*/