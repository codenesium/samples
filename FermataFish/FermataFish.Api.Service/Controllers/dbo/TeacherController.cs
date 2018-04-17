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
	[Route("api/teachers")]
	[ApiVersion("1.0")]
	public class TeacherController: AbstractTeacherController
	{
		public TeacherController(
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacher teacherManager
			)
			: base(logger,
			       transactionCoordinator,
			       teacherManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f53740e548caef86276ccd67b3e7523b</Hash>
</Codenesium>*/