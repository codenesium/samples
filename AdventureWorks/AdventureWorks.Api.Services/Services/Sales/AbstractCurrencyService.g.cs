using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICurrencyRepository CurrencyRepository { get; private set; }

		protected IApiCurrencyServerRequestModelValidator CurrencyModelValidator { get; private set; }

		protected IDALCurrencyMapper DalCurrencyMapper { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<Currency> records = await this.CurrencyRepository.All(limit, offset, query);

			return this.DalCurrencyMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCurrencyServerResponseModel> Get(string currencyCode)
		{
			Currency record = await this.CurrencyRepository.Get(currencyCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCurrencyMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyServerResponseModel>> Create(
			ApiCurrencyServerRequestModel model)
		{
			CreateResponse<ApiCurrencyServerResponseModel> response = ValidationResponseFactory<ApiCurrencyServerResponseModel>.CreateResponse(await this.CurrencyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Currency record = this.DalCurrencyMapper.MapModelToEntity(default(string), model);
				record = await this.CurrencyRepository.Create(record);

				response.SetRecord(this.DalCurrencyMapper.MapEntityToModel(record));
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
				Currency record = this.DalCurrencyMapper.MapModelToEntity(currencyCode, model);
				await this.CurrencyRepository.Update(record);

				record = await this.CurrencyRepository.Get(currencyCode);

				ApiCurrencyServerResponseModel apiModel = this.DalCurrencyMapper.MapEntityToModel(record);
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
				return this.DalCurrencyMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByFromCurrencyCode(fromCurrencyCode, limit, offset);

			return this.DalCurrencyRateMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByToCurrencyCode(toCurrencyCode, limit, offset);

			return this.DalCurrencyRateMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>29e2e8f74f2c419594179109ba59eb63</Hash>
</Codenesium>*/