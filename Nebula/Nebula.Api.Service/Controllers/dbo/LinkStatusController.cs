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
	[Route("api/linkStatus")]
	public class LinkStatusController: LinkStatusControllerAbstract
	{
		public LinkStatusController(
			ILogger<LinkStatusController> logger,
			ApplicationContext context,
			LinkStatusRepository linkStatusRepository,
			LinkStatusModelValidator linkStatusModelValidator
			) : base(logger,
			         context,
			         linkStatusRepository,
			         linkStatusModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>63ad310a2f5d5cf264f21f393f5659c3</Hash>
</Codenesium>*/