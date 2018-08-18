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
			IDALAWBuildVersionMapper dalaWBuildVersionMapper
			)
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
    <Hash>a4aca3dfa6962e2dad9619002386c6b0</Hash>
</Codenesium>*/