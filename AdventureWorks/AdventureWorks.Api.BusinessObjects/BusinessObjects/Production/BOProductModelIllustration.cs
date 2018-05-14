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
	public class BOProductModelIllustration: AbstractBOProductModelIllustration, IBOProductModelIllustration
	{
		public BOProductModelIllustration(
			ILogger<ProductModelIllustrationRepository> logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationModelValidator productModelIllustrationModelValidator)
			: base(logger, productModelIllustrationRepository, productModelIllustrationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5270bdb1be399b1d4f835d233a517f5b</Hash>
</Codenesium>*/