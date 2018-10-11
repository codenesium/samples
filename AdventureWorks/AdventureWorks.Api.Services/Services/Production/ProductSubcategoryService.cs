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
	public partial class ProductSubcategoryService : AbstractProductSubcategoryService, IProductSubcategoryService
	{
		public ProductSubcategoryService(
			ILogger<IProductSubcategoryRepository> logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper bolproductSubcategoryMapper,
			IDALProductSubcategoryMapper dalproductSubcategoryMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       productSubcategoryRepository,
			       productSubcategoryModelValidator,
			       bolproductSubcategoryMapper,
			       dalproductSubcategoryMapper,
			       bolProductMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f9b325f1b6e3579ac2bfb578389e9ff5</Hash>
</Codenesium>*/