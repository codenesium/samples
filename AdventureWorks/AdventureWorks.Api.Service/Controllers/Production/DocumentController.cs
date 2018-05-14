using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/documents")]
	[ApiVersion("1.0")]
	public class DocumentController: AbstractDocumentController
	{
		public DocumentController(
			ServiceSettings settings,
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODocument documentManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       documentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5ebc5db0e2d9406d8eeeff3482b57ef3</Hash>
</Codenesium>*/