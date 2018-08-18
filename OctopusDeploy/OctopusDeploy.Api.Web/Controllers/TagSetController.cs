using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/tagSets")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TagSetController : AbstractTagSetController
	{
		public TagSetController(
			ApiSettings settings,
			ILogger<TagSetController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITagSetService tagSetService,
			IApiTagSetModelMapper tagSetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tagSetService,
			       tagSetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a9796827f6f59b6ff55cfc23ca88db97</Hash>
</Codenesium>*/