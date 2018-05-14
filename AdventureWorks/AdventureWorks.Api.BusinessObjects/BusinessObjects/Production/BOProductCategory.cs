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
			IApiProductCategoryModelValidator productCategoryModelValidator)
			: base(logger, productCategoryRepository, productCategoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e3f7d00d4b98f22460277a5e5a034830</Hash>
</Codenesium>*/