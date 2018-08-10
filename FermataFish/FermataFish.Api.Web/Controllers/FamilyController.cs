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
	[Route("api/families")]
	[ApiController]
	[ApiVersion("1.0")]
	public class FamilyController : AbstractFamilyController
	{
		public FamilyController(
			ApiSettings settings,
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyService familyService,
			IApiFamilyModelMapper familyModelMapper
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
    <Hash>5a8bfd91d5e3c4b707b8f9ecf3c9b76d</Hash>
</Codenesium>*/