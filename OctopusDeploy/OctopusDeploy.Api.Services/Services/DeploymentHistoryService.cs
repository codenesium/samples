using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class DeploymentHistoryService : AbstractDeploymentHistoryService, IDeploymentHistoryService
	{
		public DeploymentHistoryService(
			ILogger<IDeploymentHistoryRepository> logger,
			IDeploymentHistoryRepository deploymentHistoryRepository,
			IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
			IBOLDeploymentHistoryMapper boldeploymentHistoryMapper,
			IDALDeploymentHistoryMapper daldeploymentHistoryMapper
			)
			: base(logger,
			       deploymentHistoryRepository,
			       deploymentHistoryModelValidator,
			       boldeploymentHistoryMapper,
			       daldeploymentHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>80325e261b3df674d90d0c4fe632d25f</Hash>
</Codenesium>*/