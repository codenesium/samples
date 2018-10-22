using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<ITeacherSkillRepository> logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolteacherSkillMapper,
			IDALTeacherSkillMapper dalteacherSkillMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       bolteacherSkillMapper,
			       dalteacherSkillMapper,
			       bolRateMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>92acd15cda24b223728a23cf66125a97</Hash>
</Codenesium>*/