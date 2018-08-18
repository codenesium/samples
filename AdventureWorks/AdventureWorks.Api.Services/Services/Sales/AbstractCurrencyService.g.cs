using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCurrencyService : AbstractService
	{
		protected ICurrencyRepository CurrencyRepository { get; private set; }

		protected IApiCurrencyRequestModelValidator CurrencyModelValidator { get; private set; }

		protected IBOLCurrencyMapper BolCurrencyMapper { get; private set; }

		protected IDALCurrencyMapper DalCurrencyMapper { get; private set; }

		protected IBOLCountryRegionCurrencyMapper BolCountryRegionCurrencyMapper { get; private set; }

		protected IDALCountryRegionCurrencyMapper DalCountryRegionCurrencyMapper { get; private set; }

		protected IBOLCurrencyRateMapper BolCurrencyRateMapper { get; private set; }

		protected IDALCurrencyRateMapper DalCurrencyRateMapper { get; private set; }

		private ILogger logger;

		public AbstractCurrencyService(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolCurrencyMapper,
			IDALCurrencyMapper dalCurrencyMapper,
			IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
			IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base()
		{
			this.CurrencyRepository = currencyRepository;
			this.CurrencyModelValidator = currencyModelValidator;
			this.BolCurrencyMapper = bolCurrencyMapper;
			this.DalCurrencyMapper = dalCurrencyMapper;
			this.BolCountryRegionCurrencyMapper = bolCountryRegionCurrencyMapper;
			this.DalCountryRegionCurrencyMapper = dalCountryRegionCurrencyMapper;
			this.BolCurrencyRateMapper = bolCurrencyRateMapper;
			this.DalCurrencyRateMapper = dalCurrencyRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CurrencyRepository.All(limit, offset);

			return this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCurrencyResponseModel> Get(string currencyCode)
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

		public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> Create(
			ApiCurrencyRequestModel model)
		{
			CreateResponse<ApiCurrencyResponseModel> response = new CreateResponse<ApiCurrencyResponseModel>(await this.CurrencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCurrencyMapper.MapModelToBO(default(string), model);
				var record = await this.CurrencyRepository.Create(this.DalCurrencyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCurrencyResponseModel>> Update(
			string currencyCode,
			ApiCurrencyRequestModel model)
		{
			var validationResult = await this.CurrencyModelValidator.ValidateUpdateAsync(currencyCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCurrencyMapper.MapModelToBO(currencyCode, model);
				await this.CurrencyRepository.Update(this.DalCurrencyMapper.MapBOToEF(bo));

				var record = await this.CurrencyRepository.Get(currencyCode);

				return new UpdateResponse<ApiCurrencyResponseModel>(this.BolCurrencyMapper.MapBOToModel(this.DalCurrencyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCurrencyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string currencyCode)
		{
			ActionResponse response = new ActionResponse(await this.CurrencyModelValidator.ValidateDeleteAsync(currencyCode));
			if (response.Success)
			{
				await this.CurrencyRepository.Delete(currencyCode);
			}

			return response;
		}

		public async Task<ApiCurrencyResponseModel> ByName(string name)
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

		public async virtual Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CountryRegionCurrency> records = await this.CurrencyRepository.CountryRegionCurrencies(currencyCode, limit, offset);

			return this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			List<CurrencyRate> records = await this.CurrencyRepository.CurrencyRates(fromCurrencyCode, limit, offset);

			return this.BolCurrencyRateMapper.MapBOToModel(this.DalCurrencyRateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a5e480078940040ce07d93669277a4ba</Hash>
</Codenesium>*/