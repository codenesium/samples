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
	public class BOIllustration: AbstractBOIllustration, IBOIllustration
	{
		public BOIllustration(
			ILogger<IllustrationRepository> logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationModelValidator illustrationModelValidator)
			: base(logger, illustrationRepository, illustrationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6183d2e96b259d0a16e95c2f925bd230</Hash>
</Codenesium>*/