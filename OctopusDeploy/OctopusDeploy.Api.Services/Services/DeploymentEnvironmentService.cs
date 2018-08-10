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
	public partial class DeploymentEnvironmentService : AbstractDeploymentEnvironmentService, IDeploymentEnvironmentService
	{
		public DeploymentEnvironmentService(
			ILogger<IDeploymentEnvironmentRepository> logger,
			IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
			IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
			IBOLDeploymentEnvironmentMapper boldeploymentEnvironmentMapper,
			IDALDeploymentEnvironmentMapper daldeploymentEnvironmentMapper
			)
			: base(logger,
			       deploymentEnvironmentRepository,
			       deploymentEnvironmentModelValidator,
			       boldeploymentEnvironmentMapper,
			       daldeploymentEnvironmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5dea11f3fd400fd094699c5563b60dab</Hash>
</Codenesium>*/