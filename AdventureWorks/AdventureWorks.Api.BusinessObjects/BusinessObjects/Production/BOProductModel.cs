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
			IProductModelModelValidator productModelModelValidator)
			: base(logger, productModelRepository, productModelModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>99ed3685be0b0d4ecaba5537850a9b9d</Hash>
</Codenesium>*/