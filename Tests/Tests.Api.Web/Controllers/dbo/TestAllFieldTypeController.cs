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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/testAllFieldTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class TestAllFieldTypeController : AbstractTestAllFieldTypeController
	{
		public TestAllFieldTypeController(
			ApiSettings settings,
			ILogger<TestAllFieldTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITestAllFieldTypeService testAllFieldTypeService,
			IApiTestAllFieldTypeServerModelMapper testAllFieldTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       testAllFieldTypeService,
			       testAllFieldTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>14b9566b24dd387c7051ed4ee98f0d6f</Hash>
</Codenesium>*/