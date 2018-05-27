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
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper productModelProductDescriptionCultureMapper)
			: base(logger, productModelProductDescriptionCultureRepository, productModelProductDescriptionCultureModelValidator, productModelProductDescriptionCultureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0a28c7ed3bc512c59e0f496b3b6e54a8</Hash>
</Codenesium>*/