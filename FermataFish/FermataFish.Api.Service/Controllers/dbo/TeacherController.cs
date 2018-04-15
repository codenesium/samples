using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/teachers")]
	[ApiVersion("1.0")]
	public class TeacherController: AbstractTeacherController
	{
		public TeacherController(
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherRepository teacherRepository,
			ITeacherModelValidator teacherModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       teacherRepository,
			       teacherModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f07af13505ba3794c817191a51e35bf5</Hash>
</Codenesium>*/