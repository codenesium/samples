using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class MachineService : AbstractMachineService, IMachineService
	{
		public MachineService(
			ILogger<IMachineRepository> logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolmachineMapper,
			IDALMachineMapper dalmachineMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       machineRepository,
			       machineModelValidator,
			       bolmachineMapper,
			       dalmachineMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40ec6ece32dca852b6e869d3b8218955</Hash>
</Codenesium>*/