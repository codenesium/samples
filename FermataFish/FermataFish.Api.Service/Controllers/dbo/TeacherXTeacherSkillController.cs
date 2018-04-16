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
	[Route("api/teacherXTeacherSkills")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(TeacherXTeacherSkillFilter))]
	public class TeacherXTeacherSkillController: AbstractTeacherXTeacherSkillController
	{
		public TeacherXTeacherSkillController(
			ILogger<TeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository
			)
			: base(logger,
			       transactionCoordinator,
			       teacherXTeacherSkillRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9686e5898b8749f480ba0baab15358a6</Hash>
</Codenesium>*/