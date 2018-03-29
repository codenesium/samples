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
			ApplicationContext context,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator
			) : base(logger,
			         context,
			         claspRepository,
			         claspModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a5cf5e418d2579771982bbfc2e009630</Hash>
</Codenesium>*/