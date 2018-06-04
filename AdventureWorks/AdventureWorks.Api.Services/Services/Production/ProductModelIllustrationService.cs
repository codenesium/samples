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
	public class ProductModelIllustrationService: AbstractProductModelIllustrationService, IProductModelIllustrationService
	{
		public ProductModelIllustrationService(
			ILogger<ProductModelIllustrationRepository> logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
			IBOLProductModelIllustrationMapper BOLproductModelIllustrationMapper,
			IDALProductModelIllustrationMapper DALproductModelIllustrationMapper)
			: base(logger, productModelIllustrationRepository,
			       productModelIllustrationModelValidator,
			       BOLproductModelIllustrationMapper,
			       DALproductModelIllustrationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5fc9e0224199d4a67d250e5c260c9e42</Hash>
</Codenesium>*/