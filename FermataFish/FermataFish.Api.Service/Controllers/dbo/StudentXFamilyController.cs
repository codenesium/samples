using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/studentXFamilies")]
	public class StudentXFamilyController: AbstractStudentXFamilyController
	{
		public StudentXFamilyController(
			ILogger<StudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentXFamilyRepository studentXFamilyRepository,
			IStudentXFamilyModelValidator studentXFamilyModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       studentXFamilyRepository,
			       studentXFamilyModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f7b8784348190a7ccee741bd3ce0f59e</Hash>
</Codenesium>*/