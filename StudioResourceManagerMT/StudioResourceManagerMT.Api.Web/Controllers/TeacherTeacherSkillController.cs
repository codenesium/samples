using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
{
	[Route("api/teacherTeacherSkills")]
	[ApiController]
	[ApiVersion("1.0")]

	public class TeacherTeacherSkillController : AbstractTeacherTeacherSkillController
	{
		public TeacherTeacherSkillController(
			ApiSettings settings,
			ILogger<TeacherTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherTeacherSkillService teacherTeacherSkillService,
			IApiTeacherTeacherSkillServerModelMapper teacherTeacherSkillModelMapper
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
    <Hash>0b3503a325ec50d89b64ff6108c14a02</Hash>
</Codenesium>*/