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
	[Route("api/teacherSkills")]
	[ApiVersion("1.0")]
	public class TeacherSkillController: AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherSkill teacherSkillManager
			)
			: base(logger,
			       transactionCoordinator,
			       teacherSkillManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4c069244986ae9bfedacde51033d5300</Hash>
</Codenesium>*/