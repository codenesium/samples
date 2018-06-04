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
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
	[Route("api/teacherSkills")]
	[ApiVersion("1.0")]
	public class TeacherSkillController: AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ServiceSettings settings,
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillService teacherSkillService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherSkillService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>743bba8043831a5d394f50a53de0fae7</Hash>
</Codenesium>*/