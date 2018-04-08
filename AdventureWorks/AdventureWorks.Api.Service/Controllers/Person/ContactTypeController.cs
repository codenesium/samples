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
	public class ContactTypesController: AbstractContactTypesController
	{
		public ContactTypesController(
			ILogger<ContactTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         contactTypeRepository,
			         contactTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ebd1048899ddb0fa9f36d08c3b110c8d</Hash>
</Codenesium>*/