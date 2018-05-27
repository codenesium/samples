using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBORate: AbstractBOManager
	{
		private IRateRepository rateRepository;
		private IApiRateRequestModelValidator rateModelValidator;
		private IBOLRateMapper rateMapper;
		private ILogger logger;

		public AbstractBORate(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper rateMapper)
			: base()

		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
			this.rateMapper = rateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.rateRepository.All(skip, take, orderClause);

			return this.rateMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiRateResponseModel> Get(int id)
		{
			var record = await rateRepository.Get(id);

			return this.rateMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiRateResponseModel>> Create(
			ApiRateRequestModel model)
		{
			CreateResponse<ApiRateResponseModel> response = new CreateResponse<ApiRateResponseModel>(await this.rateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.rateMapper.MapModelToDTO(default (int), model);
				var record = await this.rateRepository.Create(dto);

				response.SetRecord(this.rateMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiRateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.rateMapper.MapModelToDTO(id, model);
				await this.rateRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.rateRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7993285b74ee8f7ef29e36b67fe81dc9</Hash>
</Codenesium>*/