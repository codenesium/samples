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
	public class BOProductDescription: AbstractBOProductDescription, IBOProductDescription
	{
		public BOProductDescription(
			ILogger<ProductDescriptionRepository> logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper productDescriptionMapper)
			: base(logger, productDescriptionRepository, productDescriptionModelValidator, productDescriptionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>27b41febcd50d52acc0f37eb4b86c1f6</Hash>
</Codenesium>*/