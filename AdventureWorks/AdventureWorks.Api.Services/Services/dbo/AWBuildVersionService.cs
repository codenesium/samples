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
	public class AWBuildVersionService: AbstractAWBuildVersionService, IAWBuildVersionService
	{
		public AWBuildVersionService(
			ILogger<AWBuildVersionRepository> logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper BOLaWBuildVersionMapper,
			IDALAWBuildVersionMapper DALaWBuildVersionMapper)
			: base(logger, aWBuildVersionRepository,
			       aWBuildVersionModelValidator,
			       BOLaWBuildVersionMapper,
			       DALaWBuildVersionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>9158f71314e0f1368145ba023cf4a7f3</Hash>
</Codenesium>*/