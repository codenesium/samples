using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class AWBuildVersionService : AbstractAWBuildVersionService, IAWBuildVersionService
	{
		public AWBuildVersionService(
			ILogger<IAWBuildVersionRepository> logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolaWBuildVersionMapper,
			IDALAWBuildVersionMapper dalaWBuildVersionMapper)
			: base(logger,
			       aWBuildVersionRepository,
			       aWBuildVersionModelValidator,
			       bolaWBuildVersionMapper,
			       dalaWBuildVersionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b4e209942f04bc1d7adf6854c16292b4</Hash>
</Codenesium>*/