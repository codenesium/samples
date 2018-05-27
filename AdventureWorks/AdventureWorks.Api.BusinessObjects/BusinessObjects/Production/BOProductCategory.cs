using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductCategory: AbstractBOProductCategory, IBOProductCategory
	{
		public BOProductCategory(
			ILogger<ProductCategoryRepository> logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper productCategoryMapper)
			: base(logger, productCategoryRepository, productCategoryModelValidator, productCategoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c1de2923f1c9a43e7b0fe056025c0773</Hash>
</Codenesium>*/