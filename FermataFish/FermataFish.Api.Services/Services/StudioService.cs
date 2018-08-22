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
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLLessonStatusMapper bolLessonStatusMapper,
			IDALLessonStatusMapper dalLessonStatusMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLLessonMapper bolLessonMapper,
			IDALLessonMapper dalLessonMapper,
			IBOLLessonXStudentMapper bolLessonXStudentMapper,
			IDALLessonXStudentMapper dalLessonXStudentMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper
			)
			: base(logger,
			       studioRepository,
			       studioModelValidator,
			       bolstudioMapper,
			       dalstudioMapper,
			       bolFamilyMapper,
			       dalFamilyMapper,
			       bolLessonStatusMapper,
			       dalLessonStatusMapper,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolLessonMapper,
			       dalLessonMapper,
			       bolLessonXStudentMapper,
			       dalLessonXStudentMapper,
			       bolRateMapper,
			       dalRateMapper,
			       bolSpaceMapper,
			       dalSpaceMapper,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper,
			       bolSpaceXSpaceFeatureMapper,
			       dalSpaceXSpaceFeatureMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolStudentXFamilyMapper,
			       dalStudentXFamilyMapper,
			       bolTeacherMapper,
			       dalTeacherMapper,
			       bolTeacherSkillMapper,
			       dalTeacherSkillMapper,
			       bolTeacherXTeacherSkillMapper,
			       dalTeacherXTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>41cabe32fc6d6bcb61bb430a84f7db96</Hash>
</Codenesium>*/