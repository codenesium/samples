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
			IApiMachineModelValidator machineModelValidator)
			: base(logger, machineRepository, machineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>973845a84a27f8e90d739a06a6e3c998</Hash>
</Codenesium>*/