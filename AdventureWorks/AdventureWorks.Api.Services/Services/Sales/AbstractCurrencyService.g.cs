using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyService : AbstractService
	{
		private IMediator mediator;

		protected ICurrencyRepository CurrencyRepository { get; private set; }

		protected IApiCurrencyServerRequestModelValidator CurrencyModelValidator { get; private set; }

		protected IDALCurrencyMapper DalCurrencyMapper { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyService(
			ILogger logger,
			IMediator mediator,
			ICurrencyRepository currencyRepository,
			IApiCurrencyServerRequestModelValidator currencyModelValidator,
			IDALCurrencyMapper dalCurrencyMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base()
		{
			this.CurrencyRepository = currencyRepository;
			this.CurrencyModelValidator = currencyModelValidator;
			this.DalCurrencyMapper = dalCurrencyMapper;
			this.DalCurrencyRateMapper = dalCurrencyRateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCurrencyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.CurrencyRepository.All(limit, offset, query);

			return this.DalCurrencyMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiCurrencyServerResponseModel> Get(string currencyCode)
		{
			var record = await this.CurrencyRepository.Get(currencyCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCurrencyMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyServerResponseModel>> Create(
			ApiCurrencyServerRequestModel model)
		{
			CreateResponse<ApiCurrencyServerResponseModel> response = ValidationResponseFactory<ApiCurrencyServerResponseModel>.CreateResponse(await this.CurrencyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCurrencyMapper.MapModelToBO(default(string), model);
				var record = await this.CurrencyRepository.Create(bo);

				response.SetRecord(this.DalCurrencyMapper.MapBOToModel(record));
				await this.mediator.Publish(new CurrencyCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCurrencyServerResponseModel>> Update(
			string currencyCode,
			ApiCurrencyServerRequestModel model)
		{
			var validationResult = await this.CurrencyModelValidator.ValidateUpdateAsync(currencyCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalCurrencyMapper.MapModelToBO(currencyCode, model);
				await this.CurrencyRepository.Update(bo);

				var record = await this.CurrencyRepository.Get(currencyCode);

				var apiModel = this.DalCurrencyMapper.MapBOToModel(record);
				await this.mediator.Publish(new CurrencyUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCurrencyServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCurrencyServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string currencyCode)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CurrencyModelValidator.ValidateDeleteAsync(currencyCode));

			if (response.Success)
			{
				await this.CurrencyRepository.Delete(currencyCode);

				await this.mediator.Publish(new CurrencyDeletedNotification(currencyCode));
			}

			return response;
		}

		public async virtual Task<ApiCurrencyServerResponseModel> ByName(string name)
		{
			Currency record = await this.CurrencyRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCurrencyMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByFromCurrencyCode(fromCurrencyCode, limit, offset);

			return this.DalCurrencyRateMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByToCurrencyCode(toCurrencyCode, limit, offset);

			return this.DalCurrencyRateMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f6b9c8b6aec1de16f1e73ff03abaded4</Hash>
</Codenesium>*/