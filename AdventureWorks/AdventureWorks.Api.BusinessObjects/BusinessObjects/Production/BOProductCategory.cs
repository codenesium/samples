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
			IProductCategoryModelValidator productCategoryModelValidator)
			: base(logger, productCategoryRepository, productCategoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>80b10c23138429abd38777c2d4aa1079</Hash>
</Codenesium>*/