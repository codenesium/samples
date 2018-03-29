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
	[Route("api/linkStatus")]
	public class LinkStatusController: AbstractLinkStatusController
	{
		public LinkStatusController(
			ILogger<LinkStatusController> logger,
			ApplicationContext context,
			ILinkStatusRepository linkStatusRepository,
			ILinkStatusModelValidator linkStatusModelValidator
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
    <Hash>38903f98f446130fd32a4b189c3e2bc4</Hash>
</Codenesium>*/