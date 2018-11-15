using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/families")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class FamilyController : AbstractFamilyController
	{
		public FamilyController(
			ApiSettings settings,
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyService familyService,
			IApiFamilyServerModelMapper familyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       familyService,
			       familyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e7ca682a9dbcc3cd0a5609fdd4c4e9e6</Hash>
</Codenesium>*/