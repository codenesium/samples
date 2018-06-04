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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyRateService: AbstractService
	{
		private ICurrencyRateRepository currencyRateRepository;
		private IApiCurrencyRateRequestModelValidator currencyRateModelValidator;
		private IBOLCurrencyRateMapper BOLCurrencyRateMapper;
		private IDALCurrencyRateMapper DALCurrencyRateMapper;
		private ILogger logger;

		public AbstractCurrencyRateService(
			ILogger logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper bolcurrencyRateMapper,
			IDALCurrencyRateMapper dalcurrencyRateMapper)
			: base()

		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
			this.BOLCurrencyRateMapper = bolcurrencyRateMapper;
			this.DALCurrencyRateMapper = dalcurrencyRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.currencyRateRepository.All(skip, take, orderClause);

			return this.BOLCurrencyRateMapper.MapBOToModel(this.DALCurrencyRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCurrencyRateResponseModel> Get(int currencyRateID)
		{
			var record = await currencyRateRepository.Get(currencyRateID);

			return this.BOLCurrencyRateMapper.MapBOToModel(this.DALCurrencyRateMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
			ApiCurrencyRateRequestModel model)
		{
			CreateResponse<ApiCurrencyRateResponseModel> response = new CreateResponse<ApiCurrencyRateResponseModel>(await this.currencyRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCurrencyRateMapper.MapModelToBO(default (int), model);
				var record = await this.currencyRateRepository.Create(this.DALCurrencyRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCurrencyRateMapper.MapBOToModel(this.DALCurrencyRateMapper.MapEFToBO(record)));
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
				var bo = this.BOLCurrencyRateMapper.MapModelToBO(currencyRateID, model);
				await this.currencyRateRepository.Update(this.DALCurrencyRateMapper.MapBOToEF(bo));
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
			CurrencyRate record = await this.currencyRateRepository.GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate,fromCurrencyCode,toCurrencyCode);

			return this.BOLCurrencyRateMapper.MapBOToModel(this.DALCurrencyRateMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>6e7bc2506d6dcc9cd12ececfc12ba652</Hash>
</Codenesium>*/