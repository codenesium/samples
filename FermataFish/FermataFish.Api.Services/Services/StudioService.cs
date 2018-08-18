using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class StudioService : AbstractStudioService, IStudioService
	{
		public StudioService(
			ILogger<IStudioRepository> logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolstudioMapper,
			IDALStudioMapper dalstudioMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper,
			IBOLLessonStatusMapper bolLessonStatusMapper,
			IDALLessonStatusMapper dalLessonStatusMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper
			)
			: base(logger,
			       studioRepository,
			       studioModelValidator,
			       bolstudioMapper,
			       dalstudioMapper,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolFamilyMapper,
			       dalFamilyMapper,
			       bolLessonMapper,
			       dalLessonMapper,
			       bolLessonStatusMapper,
			       dalLessonStatusMapper,
			       bolSpaceMapper,
			       dalSpaceMapper,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolTeacherMapper,
			       dalTeacherMapper,
			       bolTeacherSkillMapper,
			       dalTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fd7275ea9273bee03bd4f6bed6bfcd8e</Hash>
</Codenesium>*/