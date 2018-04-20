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
	[Route("api/teachers")]
	[ApiVersion("1.0")]
	[Response]
	public class TeacherController: AbstractTeacherController
	{
		public TeacherController(
			ServiceSettings settings,
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacher teacherManager
			)
			: base(settings,
			       logger,
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
    <Hash>556900e080dfe9dc2bca275fab19d9a7</Hash>
</Codenesium>*/