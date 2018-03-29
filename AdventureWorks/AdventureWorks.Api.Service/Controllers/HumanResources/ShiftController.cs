using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/shifts")]
	public class ShiftsController: AbstractShiftsController
	{
		public ShiftsController(
			ILogger<ShiftsController> logger,
			ApplicationContext context,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator
			) : base(logger,
			         context,
			         shiftRepository,
			         shiftModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bdd96aacd7b2571a758adb491702f8af</Hash>
</Codenesium>*/