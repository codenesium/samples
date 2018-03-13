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
	public class ClaspsController: ClaspsControllerAbstract
	{
		public ClaspsController(
			ILogger<ClaspsController> logger,
			ApplicationContext context,
			ClaspRepository claspRepository,
			ClaspModelValidator claspModelValidator
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
    <Hash>0414850f73270c11caf8a08bfc5b9369</Hash>
</Codenesium>*/