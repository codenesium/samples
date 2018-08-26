using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/communityActionTemplates")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class CommunityActionTemplateController : AbstractCommunityActionTemplateController
	{
		public CommunityActionTemplateController(
			ApiSettings settings,
			ILogger<CommunityActionTemplateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICommunityActionTemplateService communityActionTemplateService,
			IApiCommunityActionTemplateModelMapper communityActionTemplateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       communityActionTemplateService,
			       communityActionTemplateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>13a3c148f196dc743aeff9a62f8cfea3</Hash>
</Codenesium>*/