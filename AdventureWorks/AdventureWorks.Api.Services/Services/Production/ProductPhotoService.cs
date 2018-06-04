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
	public class ProductPhotoService: AbstractProductPhotoService, IProductPhotoService
	{
		public ProductPhotoService(
			ILogger<ProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper BOLproductPhotoMapper,
			IDALProductPhotoMapper DALproductPhotoMapper)
			: base(logger, productPhotoRepository,
			       productPhotoModelValidator,
			       BOLproductPhotoMapper,
			       DALproductPhotoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3dfa2b1efe902cdb613c693d7e32efe0</Hash>
</Codenesium>*/