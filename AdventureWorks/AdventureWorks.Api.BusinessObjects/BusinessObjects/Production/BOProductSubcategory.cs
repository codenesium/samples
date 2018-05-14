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
	public class BOProductSubcategory: AbstractBOProductSubcategory, IBOProductSubcategory
	{
		public BOProductSubcategory(
			ILogger<ProductSubcategoryRepository> logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryModelValidator productSubcategoryModelValidator)
			: base(logger, productSubcategoryRepository, productSubcategoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cce7608d5c0e05139a5f0e84a88e0a5e</Hash>
</Codenesium>*/