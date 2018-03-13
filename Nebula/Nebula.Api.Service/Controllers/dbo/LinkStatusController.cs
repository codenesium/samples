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
	public class LinkStatusController: AbstractLinkStatusController
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
    <Hash>363dd6b74d63ef549d4a4c4ff8ba06ad</Hash>
</Codenesium>*/