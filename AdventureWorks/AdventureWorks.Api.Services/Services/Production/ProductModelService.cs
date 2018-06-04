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
	public class ProductModelService: AbstractProductModelService, IProductModelService
	{
		public ProductModelService(
			ILogger<ProductModelRepository> logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper BOLproductModelMapper,
			IDALProductModelMapper DALproductModelMapper)
			: base(logger, productModelRepository,
			       productModelModelValidator,
			       BOLproductModelMapper,
			       DALproductModelMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7cdec74fa6d5b30d795098f59cb40bfe</Hash>
</Codenesium>*/