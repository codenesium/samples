using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
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
	public abstract class AbstractTenantService : AbstractService
	{
		protected ITenantRepository TenantRepository { get; private set; }

		protected IApiTenantRequestModelValidator TenantModelValidator { get; private set; }

		protected IBOLTenantMapper BolTenantMapper { get; private set; }

		protected IDALTenantMapper DalTenantMapper { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		protected IBOLEventStatusMapper BolEventStatusMapper { get; private set; }

		protected IDALEventStatusMapper DalEventStatusMapper { get; private set; }

		protected IBOLFamilyMapper BolFamilyMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IBOLSpaceFeatureMapper BolSpaceFeatureMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IBOLTeacherSkillMapper BolTeacherSkillMapper { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractTenantService(
			ILogger logger,
			ITenantRepository tenantRepository,
			IApiTenantRequestModelValidator tenantModelValidator,
			IBOLTenantMapper bolTenantMapper,
			IDALTenantMapper dalTenantMapper,
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
			: base()
		{
			this.TenantRepository = tenantRepository;
			this.TenantModelValidator = tenantModelValidator;
			this.BolTenantMapper = bolTenantMapper;
			this.DalTenantMapper = dalTenantMapper;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.BolEventStatusMapper = bolEventStatusMapper;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.BolFamilyMapper = bolFamilyMapper;
			this.DalFamilyMapper = dalFamilyMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.BolSpaceFeatureMapper = bolSpaceFeatureMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.BolTeacherSkillMapper = bolTeacherSkillMapper;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTenantResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TenantRepository.All(limit, offset);

			return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTenantResponseModel> Get(int id)
		{
			var record = await this.TenantRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model)
		{
			CreateResponse<ApiTenantResponseModel> response = new CreateResponse<ApiTenantResponseModel>(await this.TenantModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTenantMapper.MapModelToBO(default(int), model);
				var record = await this.TenantRepository.Create(this.DalTenantMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTenantResponseModel>> Update(
			int id,
			ApiTenantRequestModel model)
		{
			var validationResult = await this.TenantModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTenantMapper.MapModelToBO(id, model);
				await this.TenantRepository.Update(this.DalTenantMapper.MapBOToEF(bo));

				var record = await this.TenantRepository.Get(id);

				return new UpdateResponse<ApiTenantResponseModel>(this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTenantResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TenantModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TenantRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiAdminResponseModel>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Admin> records = await this.TenantRepository.AdminsByTenantId(tenantId, limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventResponseModel>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.TenantRepository.EventsByTenantId(tenantId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventStatusResponseModel>> EventStatusesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStatus> records = await this.TenantRepository.EventStatusesByTenantId(tenantId, limit, offset);

			return this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFamilyResponseModel>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Family> records = await this.TenantRepository.FamiliesByTenantId(tenantId, limit, offset);

			return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRateResponseModel>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TenantRepository.RatesByTenantId(tenantId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceResponseModel>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Space> records = await this.TenantRepository.SpacesByTenantId(tenantId, limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceFeatureResponseModel>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceFeature> records = await this.TenantRepository.SpaceFeaturesByTenantId(tenantId, limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentResponseModel>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.TenantRepository.StudentsByTenantId(tenantId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudioResponseModel>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Studio> records = await this.TenantRepository.StudiosByTenantId(tenantId, limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherResponseModel>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.TenantRepository.TeachersByTenantId(tenantId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherSkillResponseModel>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherSkill> records = await this.TenantRepository.TeacherSkillsByTenantId(tenantId, limit, offset);

			return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserResponseModel>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.TenantRepository.UsersByTenantId(tenantId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2f11fe67bc4fe18636a773c946137c5a</Hash>
</Codenesium>*/