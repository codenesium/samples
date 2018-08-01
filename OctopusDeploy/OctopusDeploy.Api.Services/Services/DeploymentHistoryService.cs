using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>f53578e7191723f0f0298fa48705eadb</Hash>
</Codenesium>*/