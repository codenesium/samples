using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/countries")]
	[ApiVersion("1.0")]
	[Response]
	public class CountryController: AbstractCountryController
	{
		public CountryController(
			ServiceSettings settings,
			ILogger<CountryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountry countryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eebdfd0107b6bb2567c8d6c208c30b76</Hash>
</Codenesium>*/