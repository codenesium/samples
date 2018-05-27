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
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper productSubcategoryMapper)
			: base(logger, productSubcategoryRepository, productSubcategoryModelValidator, productSubcategoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>46ad31beedce7ac472d7d0c2392923dd</Hash>
</Codenesium>*/