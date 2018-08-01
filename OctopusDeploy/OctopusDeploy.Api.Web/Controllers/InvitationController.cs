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

namespace OctopusDeployNS.Api.Web
{
	[Route("api/invitations")]
	[ApiController]
	[ApiVersion("1.0")]
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
    <Hash>a5fa67d4f0dcbf938d4709ddf727d3d5</Hash>
</Codenesium>*/