using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/testAllFieldTypesNullables")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TestAllFieldTypesNullableController : AbstractTestAllFieldTypesNullableController
	{
		public TestAllFieldTypesNullableController(
			ApiSettings settings,
			ILogger<TestAllFieldTypesNullableController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITestAllFieldTypesNullableService testAllFieldTypesNullableService,
			IApiTestAllFieldTypesNullableModelMapper testAllFieldTypesNullableModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       testAllFieldTypesNullableService,
			       testAllFieldTypesNullableModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>61c4c8fda963c368e02492d11ce04c3a</Hash>
</Codenesium>*/