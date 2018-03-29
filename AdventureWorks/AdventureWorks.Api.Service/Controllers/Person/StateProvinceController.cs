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
	[Route("api/stateProvinces")]
	public class StateProvincesController: AbstractStateProvincesController
	{
		public StateProvincesController(
			ILogger<StateProvincesController> logger,
			ApplicationContext context,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator
			) : base(logger,
			         context,
			         stateProvinceRepository,
			         stateProvinceModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dd3c660a13621c9fc7e4a3aef7632b44</Hash>
</Codenesium>*/