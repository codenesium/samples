using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/states")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(StateFilter))]
	public class StateController: AbstractStateController
	{
		public StateController(
			ILogger<StateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateRepository stateRepository
			)
			: base(logger,
			       transactionCoordinator,
			       stateRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9f3a9e92c3beee85731548653bf0d0b5</Hash>
</Codenesium>*/