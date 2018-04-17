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
			IAWBuildVersionModelValidator aWBuildVersionModelValidator)
			: base(logger, aWBuildVersionRepository, aWBuildVersionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>59128a7778e1cc5179774320ddc562ab</Hash>
</Codenesium>*/