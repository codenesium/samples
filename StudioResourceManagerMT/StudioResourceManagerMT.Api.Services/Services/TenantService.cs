using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TenantService : AbstractTenantService, ITenantService
	{
		public TenantService(
			ILogger<ITenantRepository> logger,
			IMediator mediator,
			ITenantRepository tenantRepository,
			IApiTenantServerRequestModelValidator tenantModelValidator,
			IDALTenantMapper dalTenantMapper,
			IDALAdminMapper dalAdminMapper,
			IDALEventMapper dalEventMapper,
			IDALEventStatusMapper dalEventStatusMapper,
			IDALEventStudentMapper dalEventStudentMapper,
			IDALEventTeacherMapper dalEventTeacherMapper,
			IDALFamilyMapper dalFamilyMapper,
			IDALRateMapper dalRateMapper,
			IDALSpaceMapper dalSpaceMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper,
			IDALStudentMapper dalStudentMapper,
			IDALStudioMapper dalStudioMapper,
			IDALTeacherMapper dalTeacherMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       mediator,
			       tenantRepository,
			       tenantModelValidator,
			       dalTenantMapper,
			       dalAdminMapper,
			       dalEventMapper,
			       dalEventStatusMapper,
			       dalEventStudentMapper,
			       dalEventTeacherMapper,
			       dalFamilyMapper,
			       dalRateMapper,
			       dalSpaceMapper,
			       dalSpaceFeatureMapper,
			       dalSpaceSpaceFeatureMapper,
			       dalStudentMapper,
			       dalStudioMapper,
			       dalTeacherMapper,
			       dalTeacherSkillMapper,
			       dalTeacherTeacherSkillMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6da9021e39246ed87301082da7281e4</Hash>
</Codenesium>*/