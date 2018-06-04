using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductProductPhotoRepository: AbstractProductProductPhotoRepository, IProductProductPhotoRepository
	{
		public ProductProductPhotoRepository(
			ILogger<ProductProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>deac97f5f71b36bc6cf5ad1364d70e29</Hash>
</Codenesium>*/