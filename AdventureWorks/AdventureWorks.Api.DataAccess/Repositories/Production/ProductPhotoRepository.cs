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
	public class ProductPhotoRepository: AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(
			IDALProductPhotoMapper mapper,
			ILogger<ProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b1ab6fcdaa0135febd153a29ed670e86</Hash>
</Codenesium>*/