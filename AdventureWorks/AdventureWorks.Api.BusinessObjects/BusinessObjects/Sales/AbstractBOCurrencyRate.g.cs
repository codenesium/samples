using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOCurrencyRate: AbstractBOManager
	{
		private ICurrencyRateRepository currencyRateRepository;
		private IApiCurrencyRateRequestModelValidator currencyRateModelValidator;
		private IBOLCurrencyRateMapper currencyRateMapper;
		private ILogger logger;

		public AbstractBOCurrencyRate(
			ILogger logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper currencyRateMapper)
			: base()

		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
			this.currencyRateMapper = currencyRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.currencyRateRepository.All(skip, take, orderClause);

			return this.currencyRateMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCurrencyRateResponseModel> Get(int currencyRateID)
		{
			var record = await currencyRateRepository.Get(currencyRateID);

			return this.currencyRateMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
			ApiCurrencyRateRequestModel model)
		{
			CreateResponse<ApiCurrencyRateResponseModel> response = new CreateResponse<ApiCurrencyRateResponseModel>(await this.currencyRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.currencyRateMapper.MapModelToDTO(default (int), model);
				var record = await this.currencyRateRepository.Create(dto);

				response.SetRecord(this.currencyRateMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int currencyRateID,
			ApiCurrencyRateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateUpdateAsync(currencyRateID, model));

			if (response.Success)
			{
				var dto = this.currencyRateMapper.MapModelToDTO(currencyRateID, model);
				await this.currencyRateRepository.Update(currencyRateID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int currencyRateID)
		{
			ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateDeleteAsync(currencyRateID));

			if (response.Success)
			{
				await this.currencyRateRepository.Delete(currencyRateID);
			}
			return response;
		}

		public async Task<ApiCurrencyRateResponseModel> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			DTOCurrencyRate record = await this.currencyRateRepository.GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate,fromCurrencyCode,toCurrencyCode);

			return this.currencyRateMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>8d7ec9ae81b857c28e979cc39dd6a3d2</Hash>
</Codenesium>*/