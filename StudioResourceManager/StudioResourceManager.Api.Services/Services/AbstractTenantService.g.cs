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

		protected IBOLEventStatusMapper BolEventStatusMapper { get; private set; }

		protected IDALEventStatusMapper DalEventStatusMapper { get; private set; }

		protected IBOLFamilyMapper BolFamilyMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IBOLSpaceFeatureMapper BolSpaceFeatureMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

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
			IBOLEventStatusMapper bolEventStatusMapper,
			IDALEventStatusMapper dalEventStatusMapper,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper,
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
			this.BolEventStatusMapper = bolEventStatusMapper;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.BolFamilyMapper = bolFamilyMapper;
			this.DalFamilyMapper = dalFamilyMapper;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.BolSpaceFeatureMapper = bolSpaceFeatureMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
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

		public async virtual Task<List<ApiEventStatusResponseModel>> EventStatuses(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStatus> records = await this.TenantRepository.EventStatuses(tenantId, limit, offset);

			return this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFamilyResponseModel>> Families(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Family> records = await this.TenantRepository.Families(tenantId, limit, offset);

			return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceResponseModel>> Spaces(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Space> records = await this.TenantRepository.Spaces(tenantId, limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceFeature> records = await this.TenantRepository.SpaceFeatures(tenantId, limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudioResponseModel>> Studios(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<Studio> records = await this.TenantRepository.Studios(tenantId, limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<TeacherSkill> records = await this.TenantRepository.TeacherSkills(tenantId, limit, offset);

			return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserResponseModel>> Users(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.TenantRepository.Users(tenantId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>96aafc6659cbd164d28f1540efabfe15</Hash>
</Codenesium>*/