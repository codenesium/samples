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
			IProductSubcategoryModelValidator productSubcategoryModelValidator)
			: base(logger, productSubcategoryRepository, productSubcategoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d91b9d64c694f1e01c76fd5de8ae59c2</Hash>
</Codenesium>*/