using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductPhotoRepository : AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(
			ILogger<ProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>29fc2fa8e1767164871dc752919cee9a</Hash>
</Codenesium>*/