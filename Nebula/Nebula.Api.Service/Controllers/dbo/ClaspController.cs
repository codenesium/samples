using System;
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
	[Route("api/clasps")]
	public class ClaspsController: AbstractClaspsController
	{
		public ClaspsController(
			ILogger<ClaspsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator
			) : base(logger,
			         transactionCoordinator,
			         claspRepository,
			         claspModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8fb5045311f8570f5d1fdc61005fe918</Hash>
</Codenesium>*/