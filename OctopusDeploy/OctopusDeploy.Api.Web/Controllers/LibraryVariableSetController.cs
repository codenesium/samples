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
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/libraryVariableSets")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LibraryVariableSetController : AbstractLibraryVariableSetController
	{
		public LibraryVariableSetController(
			ApiSettings settings,
			ILogger<LibraryVariableSetController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILibraryVariableSetService libraryVariableSetService,
			IApiLibraryVariableSetModelMapper libraryVariableSetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       libraryVariableSetService,
			       libraryVariableSetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2e521d43a9b4de60cd26e82abb7b3988</Hash>
</Codenesium>*/