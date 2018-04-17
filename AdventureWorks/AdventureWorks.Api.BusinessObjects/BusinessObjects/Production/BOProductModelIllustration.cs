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
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator)
			: base(logger, productModelIllustrationRepository, productModelIllustrationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e00ef85ffc517dee131f02c0bdcce98e</Hash>
</Codenesium>*/