using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/studentXFamilies")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class StudentXFamilyController: AbstractStudentXFamilyController
	{
		public StudentXFamilyController(
			ILogger<StudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudentXFamily studentXFamilyManager
			)
			: base(logger,
			       transactionCoordinator,
			       studentXFamilyManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>356f08d07bc905530843ccbc27735c78</Hash>
</Codenesium>*/