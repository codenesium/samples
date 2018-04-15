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
	public class TeacherSkillController: AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillRepository teacherSkillRepository,
			ITeacherSkillModelValidator teacherSkillModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       teacherSkillRepository,
			       teacherSkillModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b27d5ec635f8e491de182c100cc161ff</Hash>
</Codenesium>*/