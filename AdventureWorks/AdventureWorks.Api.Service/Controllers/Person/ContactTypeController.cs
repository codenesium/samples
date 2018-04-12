using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/contactTypes")]
	public class ContactTypeController: AbstractContactTypeController
	{
		public ContactTypeController(
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       contactTypeRepository,
			       contactTypeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c49440644b411e1b13a3a69316cca294</Hash>
</Codenesium>*/