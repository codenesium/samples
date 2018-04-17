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
			IMachineModelValidator machineModelValidator)
			: base(logger, machineRepository, machineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6ff9914ec6c1dd656a79ee37c9a9aecc</Hash>
</Codenesium>*/