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
	public partial class DeploymentRelatedMachineService : AbstractDeploymentRelatedMachineService, IDeploymentRelatedMachineService
	{
		public DeploymentRelatedMachineService(
			ILogger<IDeploymentRelatedMachineRepository> logger,
			IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
			IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
			IBOLDeploymentRelatedMachineMapper boldeploymentRelatedMachineMapper,
			IDALDeploymentRelatedMachineMapper daldeploymentRelatedMachineMapper
			)
			: base(logger,
			       deploymentRelatedMachineRepository,
			       deploymentRelatedMachineModelValidator,
			       boldeploymentRelatedMachineMapper,
			       daldeploymentRelatedMachineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b5b463933d19f0df55b5f848575818a</Hash>
</Codenesium>*/