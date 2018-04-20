using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/students")]
	[ApiVersion("1.0")]
	[Response]
	public class StudentController: AbstractStudentController
	{
		public StudentController(
			ServiceSettings settings,
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudent studentManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       studentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>37b037c5c7cf68e98d008aa32afc19ed</Hash>
</Codenesium>*/