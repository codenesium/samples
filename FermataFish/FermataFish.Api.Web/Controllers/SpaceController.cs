using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/spaces")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SpaceController : AbstractSpaceController
	{
		public SpaceController(
			ApiSettings settings,
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceService spaceService,
			IApiSpaceModelMapper spaceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceService,
			       spaceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4a783d12afb1ef01b265f5444cff529a</Hash>
</Codenesium>*/