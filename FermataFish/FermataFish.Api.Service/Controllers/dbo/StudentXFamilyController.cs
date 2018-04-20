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
	[Route("api/studentXFamilies")]
	[ApiVersion("1.0")]
	[Response]
	public class StudentXFamilyController: AbstractStudentXFamilyController
	{
		public StudentXFamilyController(
			ServiceSettings settings,
			ILogger<StudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudentXFamily studentXFamilyManager
			)
			: base(settings,
			       logger,
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
    <Hash>c62540248dce7d00b3cda664a3f51875</Hash>
</Codenesium>*/