using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyRateService : AbstractService
	{
		private IMediator mediator;

		protected ICurrencyRateRepository CurrencyRateRepository { get; private set; }

		protected IApiCurrencyRateServerRequestModelValidator CurrencyRateModelValidator { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyRateService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.CurrencyRateRepository.All(limit, offset, query);

			return this.DalCurrencyRateMapper.MapBOToModel(records);
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
				return this.DalCurrencyRateMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyRateServerResponseModel>> Create(
			ApiCurrencyRateServerRequestModel model)
		{
			CreateResponse<ApiCurrencyRateServerResponseModel> response = ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.CreateResponse(await this.CurrencyRateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCurrencyRateMapper.MapModelToBO(default(int), model);
				var record = await this.CurrencyRateRepository.Create(bo);

				response.SetRecord(this.DalCurrencyRateMapper.MapBOToModel(record));
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
				var bo = this.DalCurrencyRateMapper.MapModelToBO(currencyRateID, model);
				await this.CurrencyRateRepository.Update(bo);

				var record = await this.CurrencyRateRepository.Get(currencyRateID);

				var apiModel = this.DalCurrencyRateMapper.MapBOToModel(record);
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
				return this.DalCurrencyRateMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CurrencyRateRepository.SalesOrderHeadersByCurrencyRateID(currencyRateID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>871439231a2270967865d02415e92086</Hash>
</Codenesium>*/