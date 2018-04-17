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
			IIllustrationModelValidator illustrationModelValidator)
			: base(logger, illustrationRepository, illustrationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>fbc0a7ceb768baec8b2019d2e200edba</Hash>
</Codenesium>*/