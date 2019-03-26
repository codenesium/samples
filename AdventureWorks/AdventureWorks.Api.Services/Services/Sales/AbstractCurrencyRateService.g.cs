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
		private MediatR.IMediator mediator;

		protected ICurrencyRateRepository CurrencyRateRepository { get; private set; }

		protected IApiCurrencyRateServerRequestModelValidator CurrencyRateModelValidator { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyRateService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateServerRequestModelValidator currencyRateModelValidator,
			IDALCurrencyRateMapper dalCurrencyRateMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CurrencyRateRepository = currencyRateRepository;
			this.CurrencyRateModelValidator = currencyRateModelValidator;
			this.DalCurrencyRateMapper = dalCurrencyRateMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCurrencyRateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CurrencyRate> records = await this.CurrencyRateRepository.All(limit, offset, query);

			return this.DalCurrencyRateMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCurrencyRateServerResponseModel> Get(int currencyRateID)
		{
			CurrencyRate record = await this.CurrencyRateRepository.Get(currencyRateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCurrencyRateMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateServerResponseModel>> Create(
			ApiCurrencyRateServerRequestModel model)
		{
			CreateResponse<ApiCurrencyRateServerResponseModel> response = ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.CreateResponse(await this.CurrencyRateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CurrencyRate record = this.DalCurrencyRateMapper.MapModelToEntity(default(int), model);
				record = await this.CurrencyRateRepository.Create(record);

				response.SetRecord(this.DalCurrencyRateMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CurrencyRateCreatedNotification(response.Record));
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
				CurrencyRate record = this.DalCurrencyRateMapper.MapModelToEntity(currencyRateID, model);
				await this.CurrencyRateRepository.Update(record);

				record = await this.CurrencyRateRepository.Get(currencyRateID);

				ApiCurrencyRateServerResponseModel apiModel = this.DalCurrencyRateMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CurrencyRateUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new CurrencyRateDeletedNotification(currencyRateID));
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
				return this.DalCurrencyRateMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CurrencyRateRepository.SalesOrderHeadersByCurrencyRateID(currencyRateID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3cbe8e71b935331e4bd4efde36bfce5c</Hash>
</Codenesium>*/