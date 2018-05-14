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
			IApiProductDescriptionModelValidator productDescriptionModelValidator)
			: base(logger, productDescriptionRepository, productDescriptionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>30199d7b33f3f2f3eb56d292d967d8d2</Hash>
</Codenesium>*/