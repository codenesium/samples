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
	public class BOProductModelProductDescriptionCulture: AbstractBOProductModelProductDescriptionCulture, IBOProductModelProductDescriptionCulture
	{
		public BOProductModelProductDescriptionCulture(
			ILogger<ProductModelProductDescriptionCultureRepository> logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator)
			: base(logger, productModelProductDescriptionCultureRepository, productModelProductDescriptionCultureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5f7c6e601ff7b7e357c000dee3b04c35</Hash>
</Codenesium>*/