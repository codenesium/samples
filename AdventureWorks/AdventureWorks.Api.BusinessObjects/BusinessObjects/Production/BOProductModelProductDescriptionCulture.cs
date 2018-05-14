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
			IApiProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator)
			: base(logger, productModelProductDescriptionCultureRepository, productModelProductDescriptionCultureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e7a6fe8969b44f3bc7e56187ca5136a8</Hash>
</Codenesium>*/