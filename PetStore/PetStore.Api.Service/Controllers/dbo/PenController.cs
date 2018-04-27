using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.BusinessObjects;

namespace PetStoreNS.Api.Service
{
	[Route("api/pens")]
	[ApiVersion("1.0")]
	[Response]
	public class PenController: AbstractPenController
	{
		public PenController(
			ServiceSettings settings,
			ILogger<PenController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPen penManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       penManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e4631bc5eaf5eb4374961230840bea90</Hash>
</Codenesium>*/