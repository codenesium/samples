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
			IProductDescriptionModelValidator productDescriptionModelValidator)
			: base(logger, productDescriptionRepository, productDescriptionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>daeb836846ebb6bb30d44df88427c175</Hash>
</Codenesium>*/