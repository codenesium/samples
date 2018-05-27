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
	public class BOProductModel: AbstractBOProductModel, IBOProductModel
	{
		public BOProductModel(
			ILogger<ProductModelRepository> logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper productModelMapper)
			: base(logger, productModelRepository, productModelModelValidator, productModelMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dca0a3a4a48d25fff8738d889e7485bb</Hash>
</Codenesium>*/