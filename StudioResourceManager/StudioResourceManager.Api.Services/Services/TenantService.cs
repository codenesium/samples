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
	public partial class TenantService : AbstractTenantService, ITenantService
	{
		public TenantService(
			ILogger<ITenantRepository> logger,
			ITenantRepository tenantRepository,
			IApiTenantRequestModelValidator tenantModelValidator,
			IBOLTenantMapper boltenantMapper,
			IDALTenantMapper daltenantMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper,
			IBOLEventStatusMapper bolEventStatusMapper,
			IDALEventStatusMapper dalEventStatusMapper,
			IBOLEventStudentMapper bolEventStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper,
			IBOLEventTeacherMapper bolEventTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLSpaceSpaceFeatureMapper bolSpaceSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       tenantRepository,
			       tenantModelValidator,
			       boltenantMapper,
			       daltenantMapper,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolEventMapper,
			       dalEventMapper,
			       bolEventStatusMapper,
			       dalEventStatusMapper,
			       bolEventStudentMapper,
			       dalEventStudentMapper,
			       bolEventTeacherMapper,
			       dalEventTeacherMapper,
			       bolFamilyMapper,
			       dalFamilyMapper,
			       bolRateMapper,
			       dalRateMapper,
			       bolSpaceMapper,
			       dalSpaceMapper,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper,
			       bolSpaceSpaceFeatureMapper,
			       dalSpaceSpaceFeatureMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolStudioMapper,
			       dalStudioMapper,
			       bolTeacherMapper,
			       dalTeacherMapper,
			       bolTeacherSkillMapper,
			       dalTeacherSkillMapper,
			       bolTeacherTeacherSkillMapper,
			       dalTeacherTeacherSkillMapper,
			       bolUserMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>116322ab980d2cde1e905165a9b6b811</Hash>
</Codenesium>*/