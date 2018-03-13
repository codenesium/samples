using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[Route("api/machines")]
	public class MachinesController: MachinesControllerAbstract
	{
		public MachinesController(
			ILogger<MachinesController> logger,
			ApplicationContext context,
			MachineRepository machineRepository,
			MachineModelValidator machineModelValidator
			) : base(logger,
			         context,
			         machineRepository,
			         machineModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>164d8d9b1ed7daebb9a2850efff05123</Hash>
</Codenesium>*/