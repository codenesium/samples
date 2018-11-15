using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractTeacherSkillService : AbstractService
	{
		protected ITeacherSkillRepository TeacherSkillRepository { get; private set; }

		protected IApiTeacherSkillServerRequestModelValidator TeacherSkillModelValidator { get; private set; }

		protected IBOLTeacherSkillMapper BolTeacherSkillMapper { get; private set; }

		protected IDALTeacherSkillMapper DalTeacherSkillMapper { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public AbstractTeacherSkillService(
			ILogger logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base()
		{
			this.TeacherSkillRepository = teacherSkillRepository;
			this.TeacherSkillModelValidator = teacherSkillModelValidator;
			this.BolTeacherSkillMapper = bolTeacherSkillMapper;
			this.DalTeacherSkillMapper = dalTeacherSkillMapper;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherSkillServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeacherSkillRepository.All(limit, offset);

			return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherSkillServerResponseModel> Get(int id)
		{
			var record = await this.TeacherSkillRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeacherSkillServerResponseModel>> Create(
			ApiTeacherSkillServerRequestModel model)
		{
			CreateResponse<ApiTeacherSkillServerResponseModel> response = ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.CreateResponse(await this.TeacherSkillModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTeacherSkillMapper.MapModelToBO(default(int), model);
				var record = await this.TeacherSkillRepository.Create(this.DalTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeacherSkillServerResponseModel>> Update(
			int id,
			ApiTeacherSkillServerRequestModel model)
		{
			var validationResult = await this.TeacherSkillModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeacherSkillMapper.MapModelToBO(id, model);
				await this.TeacherSkillRepository.Update(this.DalTeacherSkillMapper.MapBOToEF(bo));

				var record = await this.TeacherSkillRepository.Get(id);

				return ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.UpdateResponse(this.BolTeacherSkillMapper.MapBOToModel(this.DalTeacherSkillMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTeacherSkillServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TeacherSkillRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiRateServerResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			List<Rate> records = await this.TeacherSkillRepository.RatesByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b39b75e080bc626084ff6be98c1163a2</Hash>
</Codenesium>*/