using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOMachine: AbstractBOMachine, IBOMachine
	{
		public BOMachine(
			ILogger<MachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper machineMapper)
			: base(logger, machineRepository, machineModelValidator, machineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5814a78a0f6ef6e0f014e00a7eaee888</Hash>
</Codenesium>*/