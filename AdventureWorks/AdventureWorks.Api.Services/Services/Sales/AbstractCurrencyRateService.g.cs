using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyRateService : AbstractService
	{
		protected ICurrencyRateRepository CurrencyRateRepository { get; private set; }

		protected IApiCurrencyRateServerRequestModelValidator CurrencyRateModelValidator { get; private set; }

		protected IBOLCurrencyRateMapper BolCurrencyRateMapper { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyRateService(
			ILogger logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateServerRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CurrencyRateRepository = currencyRateRepository;
			this.CurrencyRateModelValidator = currencyRateModelValidator;
			this.BolCurrencyRateMapper = bolCurrencyRateMapper;
			this.DalCurrencyRateMapper = dalCurrencyRateMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyRateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CurrencyRateRepository.All(limit, offset);

			return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCurrencyRateServerResponseModel> Get(int currencyRateID)
		{
			var record = await this.CurrencyRateRepository.Get(currencyRateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateServerResponseModel>> Create(
			ApiCurrencyRateServerRequestModel model)
		{
			CreateResponse<ApiCurrencyRateServerResponseModel> response = ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.CreateResponse(await this.CurrencyRateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCurrencyRateMapper.MapModelToBO(default(int), model);
				var record = await this.CurrencyRateRepository.Create(this.DalCurrencyRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCurrencyRateServerResponseModel>> Update(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model)
		{
			var validationResult = await this.CurrencyRateModelValidator.ValidateUpdateAsync(currencyRateID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCurrencyRateMapper.MapModelToBO(currencyRateID, model);
				await this.CurrencyRateRepository.Update(this.DalCurrencyRateMapper.MapBOToEF(bo));

				var record = await this.CurrencyRateRepository.Get(currencyRateID);

				return ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.UpdateResponse(this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int currencyRateID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CurrencyRateModelValidator.ValidateDeleteAsync(currencyRateID));

			if (response.Success)
			{
				await this.CurrencyRateRepository.Delete(currencyRateID);
			}

			return response;
		}

		public async virtual Task<ApiCurrencyRateServerResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
		{
			CurrencyRate record = await this.CurrencyRateRepository.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate, fromCurrencyCode, toCurrencyCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CurrencyRateRepository.SalesOrderHeadersByCurrencyRateID(currencyRateID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d721d09e99e8dd8b67cdc0b14dca37d7</Hash>
</Codenesium>*/