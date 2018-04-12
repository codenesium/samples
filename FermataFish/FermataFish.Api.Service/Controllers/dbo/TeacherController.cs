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
	[Route("api/teachers")]
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
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>05ff403053fc654b2a2e4a11a0cecc0a</Hash>
</Codenesium>*/