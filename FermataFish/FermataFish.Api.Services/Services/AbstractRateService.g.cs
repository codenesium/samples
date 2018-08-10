using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractRateService : AbstractService
	{
		protected IRateRepository RateRepository { get; private set; }

		protected IApiRateRequestModelValidator RateModelValidator { get; private set; }

		protected IBOLRateMapper BolRateMapper { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public AbstractRateService(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
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

		public virtual async Task<List<ApiRateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RateRepository.All(limit, offset);

			return this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRateResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiRateResponseModel>> Create(
			ApiRateRequestModel model)
		{
			CreateResponse<ApiRateResponseModel> response = new CreateResponse<ApiRateResponseModel>(await this.RateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolRateMapper.MapModelToBO(default(int), model);
				var record = await this.RateRepository.Create(this.DalRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRateResponseModel>> Update(
			int id,
			ApiRateRequestModel model)
		{
			var validationResult = await this.RateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolRateMapper.MapModelToBO(id, model);
				await this.RateRepository.Update(this.DalRateMapper.MapBOToEF(bo));

				var record = await this.RateRepository.Get(id);

				return new UpdateResponse<ApiRateResponseModel>(this.BolRateMapper.MapBOToModel(this.DalRateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiRateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.RateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.RateRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>60b5433dbfd09fdc65fc36e59e7bd757</Hash>
</Codenesium>*/