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
	[ResponseFilter]
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
    <Hash>e40e26cb3cab17ede0dcd7c232325c72</Hash>
</Codenesium>*/