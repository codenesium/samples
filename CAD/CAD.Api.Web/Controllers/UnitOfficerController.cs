using CADNS.Api.Contracts;
using CADNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CADNS.Api.Web
{
	[Route("api/unitOfficers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class UnitOfficerController : AbstractUnitOfficerController
	{
		public UnitOfficerController(
			ApiSettings settings,
			ILogger<UnitOfficerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitOfficerService unitOfficerService,
			IApiUnitOfficerServerModelMapper unitOfficerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitOfficerService,
			       unitOfficerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>380d57dda15e8415d563c859ffec33e5</Hash>
</Codenesium>*/