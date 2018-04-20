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
	[Route("api/teacherSkills")]
	[ApiVersion("1.0")]
	[Response]
	public class TeacherSkillController: AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ServiceSettings settings,
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherSkill teacherSkillManager
			)
			: base(settings,
			       logger,
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
    <Hash>1f7790ce7849f71936af29f83af03c9b</Hash>
</Codenesium>*/