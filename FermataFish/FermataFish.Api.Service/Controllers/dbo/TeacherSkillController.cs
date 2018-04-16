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
	[Route("api/teacherSkills")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(TeacherSkillFilter))]
	public class TeacherSkillController: AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillRepository teacherSkillRepository
			)
			: base(logger,
			       transactionCoordinator,
			       teacherSkillRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>639d092a0b5b6af22996c676122a3cd4</Hash>
</Codenesium>*/