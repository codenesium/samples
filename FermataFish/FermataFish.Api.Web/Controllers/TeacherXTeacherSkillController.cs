using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/teacherXTeacherSkills")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TeacherXTeacherSkillController : AbstractTeacherXTeacherSkillController
	{
		public TeacherXTeacherSkillController(
			ApiSettings settings,
			ILogger<TeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherXTeacherSkillService teacherXTeacherSkillService,
			IApiTeacherXTeacherSkillModelMapper teacherXTeacherSkillModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherXTeacherSkillService,
			       teacherXTeacherSkillModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a3385663c73df9635298ce50a4d41ee7</Hash>
</Codenesium>*/