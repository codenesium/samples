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
	public class BOAWBuildVersion: AbstractBOAWBuildVersion, IBOAWBuildVersion
	{
		public BOAWBuildVersion(
			ILogger<AWBuildVersionRepository> logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionModelValidator aWBuildVersionModelValidator)
			: base(logger, aWBuildVersionRepository, aWBuildVersionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>262bc5f9c44d1a6e832c93f1bc52de9f</Hash>
</Codenesium>*/