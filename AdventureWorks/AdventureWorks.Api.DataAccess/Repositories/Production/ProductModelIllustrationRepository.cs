using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductModelIllustrationRepository: AbstractProductModelIllustrationRepository, IProductModelIllustrationRepository
	{
		public ProductModelIllustrationRepository(
			ILogger<ProductModelIllustrationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>128177a011ebf546077b053e944ed92a</Hash>
</Codenesium>*/