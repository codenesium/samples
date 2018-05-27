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
			IApiIllustrationRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper illustrationMapper)
			: base(logger, illustrationRepository, illustrationModelValidator, illustrationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b095b96c047c137eec04ad7195cf601a</Hash>
</Codenesium>*/