using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractTenantService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITenantRepository TenantRepository { get; private set; }

		protected IApiTenantServerRequestModelValidator TenantModelValidator { get; private set; }

		protected IDALTenantMapper DalTenantMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		protected IDALEventStatusMapper DalEventStatusMapper { get; private set; }

		protected IDALEventStudentMapper DalEventStudentMapper { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IDALTeacherTeacherSkillMapper DalTeacherTeacherSkillMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractTenantService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			: base()
		{
			this.TenantRepository = tenantRepository;
			this.TenantModelValidator = tenantModelValidator;
			this.DalTenantMapper = dalTenantMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.DalEventMapper = dalEventMapper;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.DalEventStudentMapper = dalEventStudentMapper;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
			this.DalFamilyMapper = dalFamilyMapper;
			this.DalRateMapper = dalRateMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.DalSpaceSpaceFeatureMapper = dalSpaceSpaceFeatureMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.DalTeacherTeacherSkillMapper = dalTeacherTeacherSkillMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTenantServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Tenant> records = await this.TenantRepository.All(limit, offset, query);

			return this.DalTenantMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTenantServerResponseModel> Get(int id)
		{
			Tenant record = await this.TenantRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTenantMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTenantServerResponseModel>> Create(
			ApiTenantServerRequestModel model)
		{
			CreateResponse<ApiTenantServerResponseModel> response = ValidationResponseFactory<ApiTenantServerResponseModel>.CreateResponse(await this.TenantModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Tenant record = this.DalTenantMapper.MapModelToEntity(default(int), model);
				record = await this.TenantRepository.Create(record);

				response.SetRecord(this.DalTenantMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TenantCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTenantServerResponseModel>> Update(
			int id,
			ApiTenantServerRequestModel model)
		{
			var validationResult = await this.TenantModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Tenant record = this.DalTenantMapper.MapModelToEntity(id, model);
				await this.TenantRepository.Update(record);

				record = await this.TenantRepository.Get(id);

				ApiTenantServerResponseModel apiModel = this.DalTenantMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TenantUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTenantServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTenantServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TenantModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TenantRepository.Delete(id);

				await this.mediator.Publish(new TenantDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiAdminServerResponseModel>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Admin> records = await this.TenantRepository.AdminsByTenantId(tenantId, limit, offset);

			return this.DalAdminMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.TenantRepository.EventsByTenantId(tenantId, limit, offset);

			return this.DalEventMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventStatusServerResponseModel>> EventStatusByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStatus> records = await this.TenantRepository.EventStatusByTenantId(tenantId, limit, offset);

			return this.DalEventStatusMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventStudentServerResponseModel>> EventStudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStudent> records = await this.TenantRepository.EventStudentsByTenantId(tenantId, limit, offset);

			return this.DalEventStudentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventTeacher> records = await this.TenantRepository.EventTeachersByTenantId(tenantId, limit, offset);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiFamilyServerResponseModel>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Family> records = await this.TenantRepository.FamiliesByTenantId(tenantId, limit, offset);

			return this.DalFamilyMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiRateServerResponseModel>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TenantRepository.RatesByTenantId(tenantId, limit, offset);

			return this.DalRateMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSpaceServerResponseModel>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Space> records = await this.TenantRepository.SpacesByTenantId(tenantId, limit, offset);

			return this.DalSpaceMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSpaceFeatureServerResponseModel>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceFeature> records = await this.TenantRepository.SpaceFeaturesByTenantId(tenantId, limit, offset);

			return this.DalSpaceFeatureMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceSpaceFeature> records = await this.TenantRepository.SpaceSpaceFeaturesByTenantId(tenantId, limit, offset);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiStudentServerResponseModel>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.TenantRepository.StudentsByTenantId(tenantId, limit, offset);

			return this.DalStudentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiStudioServerResponseModel>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Studio> records = await this.TenantRepository.StudiosByTenantId(tenantId, limit, offset);

			return this.DalStudioMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTeacherServerResponseModel>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.TenantRepository.TeachersByTenantId(tenantId, limit, offset);

			return this.DalTeacherMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTeacherSkillServerResponseModel>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherSkill> records = await this.TenantRepository.TeacherSkillsByTenantId(tenantId, limit, offset);

			return this.DalTeacherSkillMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTeacherTeacherSkillServerResponseModel>> TeacherTeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherTeacherSkill> records = await this.TenantRepository.TeacherTeacherSkillsByTenantId(tenantId, limit, offset);

			return this.DalTeacherTeacherSkillMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiUserServerResponseModel>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.TenantRepository.UsersByTenantId(tenantId, limit, offset);

			return this.DalUserMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>0175cc4ca1b86a21ae5971620de85cdf</Hash>
</Codenesium>*/