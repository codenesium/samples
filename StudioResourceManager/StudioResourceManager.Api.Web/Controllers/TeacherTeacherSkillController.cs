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
    <Hash>b9278da7266733027dfe546c1c8714c1</Hash>
</Codenesium>*/