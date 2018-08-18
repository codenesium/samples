using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/businessEntityContacts")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BusinessEntityContactController : AbstractBusinessEntityContactController
	{
		public BusinessEntityContactController(
			ApiSettings settings,
			ILogger<BusinessEntityContactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityContactService businessEntityContactService,
			IApiBusinessEntityContactModelMapper businessEntityContactModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       businessEntityContactService,
			       businessEntityContactModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a5ba27e82f50c5439c003d97a26b74bf</Hash>
</Codenesium>*/