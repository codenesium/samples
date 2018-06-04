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
	public class ProductProductPhotoService: AbstractProductProductPhotoService, IProductProductPhotoService
	{
		public ProductProductPhotoService(
			ILogger<ProductProductPhotoRepository> logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper BOLproductProductPhotoMapper,
			IDALProductProductPhotoMapper DALproductProductPhotoMapper)
			: base(logger, productProductPhotoRepository,
			       productProductPhotoModelValidator,
			       BOLproductProductPhotoMapper,
			       DALproductProductPhotoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>57780bbf4c4d380f30c76e7cf4db45a6</Hash>
</Codenesium>*/