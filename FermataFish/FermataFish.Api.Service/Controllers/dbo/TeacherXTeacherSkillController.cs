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
	[Route("api/teacherXTeacherSkills")]
	public class TeacherXTeacherSkillController: AbstractTeacherXTeacherSkillController
	{
		public TeacherXTeacherSkillController(
			ILogger<TeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       teacherXTeacherSkillRepository,
			       teacherXTeacherSkillModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>58da93b5de6e022a529205af16c5b76a</Hash>
</Codenesium>*/