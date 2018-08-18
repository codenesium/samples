using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
	{
		public ProductCategoryService(
			ILogger<IProductCategoryRepository> logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper bolproductCategoryMapper,
			IDALProductCategoryMapper dalproductCategoryMapper,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper
			)
			: base(logger,
			       productCategoryRepository,
			       productCategoryModelValidator,
			       bolproductCategoryMapper,
			       dalproductCategoryMapper,
			       bolProductSubcategoryMapper,
			       dalProductSubcategoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f019767f6110688b7e624293b6ef3f95</Hash>
</Codenesium>*/