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
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
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
			       bolFamilyMapper,
			       dalFamilyMapper,
			       bolRateMapper,
			       dalRateMapper,
			       bolSpaceMapper,
			       dalSpaceMapper,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolStudioMapper,
			       dalStudioMapper,
			       bolTeacherMapper,
			       dalTeacherMapper,
			       bolTeacherSkillMapper,
			       dalTeacherSkillMapper,
			       bolUserMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>330931de3db673be4a0c593050c2c08b</Hash>
</Codenesium>*/