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
	public partial class MachineService : AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<IMachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolmachineMapper,
			IDALMachineMapper dalmachineMapper
			)
			: base(logger,
			       machineRepository,
			       machineModelValidator,
			       bolmachineMapper,
			       dalmachineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>37bea91551e2ae09738eacdb792e02ee</Hash>
</Codenesium>*/