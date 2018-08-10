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
	public partial class DeploymentService : AbstractDeploymentService, IDeploymentService
	{
		public DeploymentService(
			ILogger<IDeploymentRepository> logger,
			IDeploymentRepository deploymentRepository,
			IApiDeploymentRequestModelValidator deploymentModelValidator,
			IBOLDeploymentMapper boldeploymentMapper,
			IDALDeploymentMapper daldeploymentMapper,
			IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
			IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper
			)
			: base(logger,
			       deploymentRepository,
			       deploymentModelValidator,
			       boldeploymentMapper,
			       daldeploymentMapper,
			       bolDeploymentRelatedMachineMapper,
			       dalDeploymentRelatedMachineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9e02139df31675fb0336b289672284d8</Hash>
</Codenesium>*/