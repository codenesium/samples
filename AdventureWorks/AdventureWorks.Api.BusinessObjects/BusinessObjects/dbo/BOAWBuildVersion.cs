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
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper aWBuildVersionMapper)
			: base(logger, aWBuildVersionRepository, aWBuildVersionModelValidator, aWBuildVersionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>fcc387bb31ac805b75b9c1019f08645b</Hash>
</Codenesium>*/