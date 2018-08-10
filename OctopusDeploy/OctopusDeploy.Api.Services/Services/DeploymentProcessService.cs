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
	public partial class DeploymentProcessService : AbstractDeploymentProcessService, IDeploymentProcessService
	{
		public DeploymentProcessService(
			ILogger<IDeploymentProcessRepository> logger,
			IDeploymentProcessRepository deploymentProcessRepository,
			IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator,
			IBOLDeploymentProcessMapper boldeploymentProcessMapper,
			IDALDeploymentProcessMapper daldeploymentProcessMapper
			)
			: base(logger,
			       deploymentProcessRepository,
			       deploymentProcessModelValidator,
			       boldeploymentProcessMapper,
			       daldeploymentProcessMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>81e116893ea908651a9cfb9baf0bd320</Hash>
</Codenesium>*/