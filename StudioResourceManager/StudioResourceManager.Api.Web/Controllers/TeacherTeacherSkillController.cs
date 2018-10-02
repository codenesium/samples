using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/teacherTeacherSkills")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class TeacherTeacherSkillController : AbstractTeacherTeacherSkillController
	{
		public TeacherTeacherSkillController(
			ApiSettings settings,
			ILogger<TeacherTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherTeacherSkillService teacherTeacherSkillService,
			IApiTeacherTeacherSkillModelMapper teacherTeacherSkillModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherTeacherSkillService,
			       teacherTeacherSkillModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>023e29f54866fc05a358d1a64c7feb8f</Hash>
</Codenesium>*/