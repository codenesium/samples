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
	[Route("api/teacherSkills")]
	[ApiController]
	[ApiVersion("1.0")]

	public class TeacherSkillController : AbstractTeacherSkillController
	{
		public TeacherSkillController(
			ApiSettings settings,
			ILogger<TeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillService teacherSkillService,
			IApiTeacherSkillServerModelMapper teacherSkillModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherSkillService,
			       teacherSkillModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>76feb8f91cc42fe29170897828e6d820</Hash>
</Codenesium>*/