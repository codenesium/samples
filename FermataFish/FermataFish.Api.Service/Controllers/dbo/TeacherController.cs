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
	[ServiceFilter(typeof(TeacherFilter))]
	public class TeacherController: AbstractTeacherController
	{
		public TeacherController(
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherRepository teacherRepository
			)
			: base(logger,
			       transactionCoordinator,
			       teacherRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f627117522c3b963066832a2eaa2ac83</Hash>
</Codenesium>*/