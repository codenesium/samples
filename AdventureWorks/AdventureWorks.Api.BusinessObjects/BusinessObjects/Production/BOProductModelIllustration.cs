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
			IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
			IBOLProductModelIllustrationMapper productModelIllustrationMapper)
			: base(logger, productModelIllustrationRepository, productModelIllustrationModelValidator, productModelIllustrationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8863a84b76081baf2dc09f4a4d4e2c37</Hash>
</Codenesium>*/