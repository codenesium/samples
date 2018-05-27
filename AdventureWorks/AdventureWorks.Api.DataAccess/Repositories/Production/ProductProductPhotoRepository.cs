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
	public class ProductProductPhotoRepository: AbstractProductProductPhotoRepository, IProductProductPhotoRepository
	{
		public ProductProductPhotoRepository(
			IDALProductProductPhotoMapper mapper,
			ILogger<ProductProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>97f5eed2a666a01f0778cc372a9da779</Hash>
</Codenesium>*/