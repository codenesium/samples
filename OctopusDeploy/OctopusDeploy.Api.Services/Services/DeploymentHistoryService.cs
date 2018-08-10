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
    <Hash>f6fbdc09a642d020bbee3f275bbea9f4</Hash>
</Codenesium>*/