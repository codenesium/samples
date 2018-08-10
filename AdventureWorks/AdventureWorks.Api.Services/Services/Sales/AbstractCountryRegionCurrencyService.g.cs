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
	public abstract class AbstractCountryRegionCurrencyService : AbstractService
	{
		protected ICountryRegionCurrencyRepository CountryRegionCurrencyRepository { get; private set; }

		protected IApiCountryRegionCurrencyRequestModelValidator CountryRegionCurrencyModelValidator { get; private set; }

		protected IBOLCountryRegionCurrencyMapper BolCountryRegionCurrencyMapper { get; private set; }

		protected IDALCountryRegionCurrencyMapper DalCountryRegionCurrencyMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryRegionCurrencyService(
			ILogger logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
			IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
			IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper)
			: base()
		{
			this.CountryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.CountryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
			this.BolCountryRegionCurrencyMapper = bolCountryRegionCurrencyMapper;
			this.DalCountryRegionCurrencyMapper = dalCountryRegionCurrencyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRegionCurrencyRepository.All(limit, offset);

			return this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode)
		{
			var record = await this.CountryRegionCurrencyRepository.Get(countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
			ApiCountryRegionCurrencyRequestModel model)
		{
			CreateResponse<ApiCountryRegionCurrencyResponseModel> response = new CreateResponse<ApiCountryRegionCurrencyResponseModel>(await this.CountryRegionCurrencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCountryRegionCurrencyMapper.MapModelToBO(default(string), model);
				var record = await this.CountryRegionCurrencyRepository.Create(this.DalCountryRegionCurrencyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryRegionCurrencyResponseModel>> Update(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model)
		{
			var validationResult = await this.CountryRegionCurrencyModelValidator.ValidateUpdateAsync(countryRegionCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCountryRegionCurrencyMapper.MapModelToBO(countryRegionCode, model);
				await this.CountryRegionCurrencyRepository.Update(this.DalCountryRegionCurrencyMapper.MapBOToEF(bo));

				var record = await this.CountryRegionCurrencyRepository.Get(countryRegionCode);

				return new UpdateResponse<ApiCountryRegionCurrencyResponseModel>(this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryRegionCurrencyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.CountryRegionCurrencyModelValidator.ValidateDeleteAsync(countryRegionCode));
			if (response.Success)
			{
				await this.CountryRegionCurrencyRepository.Delete(countryRegionCode);
			}

			return response;
		}

		public async Task<List<ApiCountryRegionCurrencyResponseModel>> ByCurrencyCode(string currencyCode)
		{
			List<CountryRegionCurrency> records = await this.CountryRegionCurrencyRepository.ByCurrencyCode(currencyCode);

			return this.BolCountryRegionCurrencyMapper.MapBOToModel(this.DalCountryRegionCurrencyMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c5f05afd36bc0eac3299e1c791af8a67</Hash>
</Codenesium>*/