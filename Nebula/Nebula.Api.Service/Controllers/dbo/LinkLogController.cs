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
	[Route("api/linkLogs")]
	public class LinkLogsController: AbstractLinkLogsController
	{
		public LinkLogsController(
			ILogger<LinkLogsController> logger,
			ApplicationContext context,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			) : base(logger,
			         context,
			         linkLogRepository,
			         linkLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>06bceb1c51c56ccb10ff31fde90fb8c1</Hash>
</Codenesium>*/