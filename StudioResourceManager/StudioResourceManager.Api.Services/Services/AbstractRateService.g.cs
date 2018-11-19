using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractRateService : AbstractService
	{
		protected IRateRepository RateRepository { get; private set; }

		protected IApiRateServerRequestModelValidator RateModelValidator { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public AbstractRateService(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateServerRequestModelValidator rateModelValidator,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base()
		{
			this.RateRepository = rateRepository;
			this.RateModelValidator = rateModelValidator;
			this.BolRateMapper = bolRateMapper;
			this.DalRateMapper = dalRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RateRepository.All(limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRateServerResponseModel> Get(int id)
		{
			var record = await this.RateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiRateServerResponseModel>> Create(
			ApiRateServerRequestModel model)
		{
			CreateResponse<ApiRateServerResponseModel> response = ValidationResponseFactory<ApiRateServerResponseModel>.CreateResponse(await this.RateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolRateMapper.MapModelToBO(default(int), model);
				var record = await this.RateRepository.Create(this.DalRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRateServerResponseModel>> Update(
			int id,
			ApiRateServerRequestModel model)
		{
			var validationResult = await this.RateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolRateMapper.MapModelToBO(id, model);
				await this.RateRepository.Update(this.DalRateMapper.MapBOToEF(bo));

				var record = await this.RateRepository.Get(id);

				return ValidationResponseFactory<ApiRateServerResponseModel>.UpdateResponse(this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiRateServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RateRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiRateServerResponseModel>> ByTeacherId(int teacherId, int limit = 0, int offset = int.MaxValue)
		{
			List<Rate> records = await this.RateRepository.ByTeacherId(teacherId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRateServerResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = 0, int offset = int.MaxValue)
		{
			List<Rate> records = await this.RateRepository.ByTeacherSkillId(teacherSkillId, limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4c5007f786f286998c1ba35eecb9e6e1</Hash>
</Codenesium>*/