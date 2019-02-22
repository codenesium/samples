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
	[Route("api/personTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PersonTypeController : AbstractPersonTypeController
	{
		public PersonTypeController(
			ApiSettings settings,
			ILogger<PersonTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonTypeService personTypeService,
			IApiPersonTypeServerModelMapper personTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personTypeService,
			       personTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>657e068675807e92c9823d60c6c8806c</Hash>
</Codenesium>*/