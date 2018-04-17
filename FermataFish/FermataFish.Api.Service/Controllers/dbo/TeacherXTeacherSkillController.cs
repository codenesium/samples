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
	[Route("api/teacherXTeacherSkills")]
	[ApiVersion("1.0")]
	public class TeacherXTeacherSkillController: AbstractTeacherXTeacherSkillController
	{
		public TeacherXTeacherSkillController(
			ILogger<TeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeacherXTeacherSkill teacherXTeacherSkillManager
			)
			: base(logger,
			       transactionCoordinator,
			       teacherXTeacherSkillManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a22337dfca29b312019e5dfb3afab664</Hash>
</Codenesium>*/