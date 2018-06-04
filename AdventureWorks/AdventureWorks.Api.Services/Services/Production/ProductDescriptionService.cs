using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductDescriptionService: AbstractProductDescriptionService, IProductDescriptionService
	{
		public ProductDescriptionService(
			ILogger<ProductDescriptionRepository> logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper BOLproductDescriptionMapper,
			IDALProductDescriptionMapper DALproductDescriptionMapper)
			: base(logger, productDescriptionRepository,
			       productDescriptionModelValidator,
			       BOLproductDescriptionMapper,
			       DALproductDescriptionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8ec14df56a6321d3de89bfe047fce2a2</Hash>
</Codenesium>*/