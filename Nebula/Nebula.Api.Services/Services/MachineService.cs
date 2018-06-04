using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class MachineService: AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<MachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper BOLmachineMapper,
			IDALMachineMapper DALmachineMapper)
			: base(logger, machineRepository,
			       machineModelValidator,
			       BOLmachineMapper,
			       DALmachineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e2e2ac5194012023e72da7a32bafaf05</Hash>
</Codenesium>*/