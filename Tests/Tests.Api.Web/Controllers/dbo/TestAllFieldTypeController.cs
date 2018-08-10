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
	[Route("api/testAllFieldTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TestAllFieldTypeController : AbstractTestAllFieldTypeController
	{
		public TestAllFieldTypeController(
			ApiSettings settings,
			ILogger<TestAllFieldTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITestAllFieldTypeService testAllFieldTypeService,
			IApiTestAllFieldTypeModelMapper testAllFieldTypeModelMapper
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
    <Hash>411e4a8d2c6b1da3cafa2ab232d68afe</Hash>
</Codenesium>*/