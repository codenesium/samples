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
	public class ProductModelProductDescriptionCultureService: AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
	{
		public ProductModelProductDescriptionCultureService(
			ILogger<ProductModelProductDescriptionCultureRepository> logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper BOLproductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper DALproductModelProductDescriptionCultureMapper)
			: base(logger, productModelProductDescriptionCultureRepository,
			       productModelProductDescriptionCultureModelValidator,
			       BOLproductModelProductDescriptionCultureMapper,
			       DALproductModelProductDescriptionCultureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a55360e7ddaa83692a9edcc28e252660</Hash>
</Codenesium>*/