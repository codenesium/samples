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
			IApiProductModelModelValidator productModelModelValidator)
			: base(logger, productModelRepository, productModelModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>af9add4b7423c18f5524a6c87ed1d8b7</Hash>
</Codenesium>*/