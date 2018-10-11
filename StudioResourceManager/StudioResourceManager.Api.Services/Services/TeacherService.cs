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
	public partial class TeacherService : AbstractTeacherService, ITeacherService
	{
		public TeacherService(
			ILogger<ITeacherRepository> logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper bolteacherMapper,
			IDALTeacherMapper dalteacherMapper,
			IBOLEventTeacherMapper bolEventTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base(logger,
			       teacherRepository,
			       teacherModelValidator,
			       bolteacherMapper,
			       dalteacherMapper,
			       bolEventTeacherMapper,
			       dalEventTeacherMapper,
			       bolRateMapper,
			       dalRateMapper,
			       bolTeacherTeacherSkillMapper,
			       dalTeacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>18ca31de5cfa46e7dc3d3a5a69028171</Hash>
</Codenesium>*/