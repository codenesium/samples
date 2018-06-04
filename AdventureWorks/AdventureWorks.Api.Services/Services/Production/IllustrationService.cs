using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class IllustrationService: AbstractIllustrationService, IIllustrationService
	{
		public IllustrationService(
			ILogger<IllustrationRepository> logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper BOLillustrationMapper,
			IDALIllustrationMapper DALillustrationMapper)
			: base(logger, illustrationRepository,
			       illustrationModelValidator,
			       BOLillustrationMapper,
			       DALillustrationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4b711d4a9ae523879360b0192ddaaf48</Hash>
</Codenesium>*/