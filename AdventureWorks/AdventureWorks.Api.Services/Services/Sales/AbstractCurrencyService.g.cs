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
		protected ICurrencyRepository CurrencyRepository { get; private set; }

		protected IApiCurrencyServerRequestModelValidator CurrencyModelValidator { get; private set; }

		protected IBOLCurrencyMapper BolCurrencyMapper { get; private set; }

		protected IDALCurrencyMapper DalCurrencyMapper { get; private set; }

		protected IBOLCurrencyRateMapper BolCurrencyRateMapper { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyService(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyServerRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolCurrencyMapper,
			IDALCurrencyMapper dalCurrencyMapper,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base()
		{
			this.CurrencyRepository = currencyRepository;
			this.CurrencyModelValidator = currencyModelValidator;
			this.BolCurrencyMapper = bolCurrencyMapper;
			this.DalCurrencyMapper = dalCurrencyMapper;
			this.BolCurrencyRateMapper = bolCurrencyRateMapper;
			this.DalCurrencyRateMapper = dalCurrencyRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CurrencyRepository.All(limit, offset);

			return this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(records));
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
				return this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCurrencyServerResponseModel>> Create(
			ApiCurrencyServerRequestModel model)
		{
			CreateResponse<ApiCurrencyServerResponseModel> response = ValidationResponseFactory<ApiCurrencyServerResponseModel>.CreateResponse(await this.CurrencyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCurrencyMapper.MapModelToBO(default(string), model);
				var record = await this.CurrencyRepository.Create(this.DalCurrencyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record)));
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
				var bo = this.BolCurrencyMapper.MapModelToBO(currencyCode, model);
				await this.CurrencyRepository.Update(this.DalCurrencyMapper.MapBOToEF(bo));

				var record = await this.CurrencyRepository.Get(currencyCode);

				return ValidationResponseFactory<ApiCurrencyServerResponseModel>.UpdateResponse(this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record)));
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
				return this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByFromCurrencyCode(fromCurrencyCode, limit, offset);

			return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRatesByToCurrencyCode(toCurrencyCode, limit, offset);

			return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7f9eed7eb2913e23cb399026b24d0556</Hash>
</Codenesium>*/