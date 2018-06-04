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
	public class ProductSubcategoryService: AbstractProductSubcategoryService, IProductSubcategoryService
	{
		public ProductSubcategoryService(
			ILogger<ProductSubcategoryRepository> logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper BOLproductSubcategoryMapper,
			IDALProductSubcategoryMapper DALproductSubcategoryMapper)
			: base(logger, productSubcategoryRepository,
			       productSubcategoryModelValidator,
			       BOLproductSubcategoryMapper,
			       DALproductSubcategoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>01943ba25a29ba40c0bf390789f427ca</Hash>
</Codenesium>*/