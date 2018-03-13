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
	public class LinkLogsController: LinkLogsControllerAbstract
	{
		public LinkLogsController(
			ILogger<LinkLogsController> logger,
			ApplicationContext context,
			LinkLogRepository linkLogRepository,
			LinkLogModelValidator linkLogModelValidator
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
    <Hash>d25564173c9d1ac602a9ffa42e1b8f5b</Hash>
</Codenesium>*/