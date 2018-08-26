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
	[Route("api/invitations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class InvitationController : AbstractInvitationController
	{
		public InvitationController(
			ApiSettings settings,
			ILogger<InvitationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IInvitationService invitationService,
			IApiInvitationModelMapper invitationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       invitationService,
			       invitationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>17f3c0ae0b74ddbf9fc6940c964b3d62</Hash>
</Codenesium>*/