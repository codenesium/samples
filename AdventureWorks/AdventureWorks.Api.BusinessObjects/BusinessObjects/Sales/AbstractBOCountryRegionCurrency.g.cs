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
	public abstract class AbstractBOCountryRegionCurrency: AbstractBOManager
	{
		private ICountryRegionCurrencyRepository countryRegionCurrencyRepository;
		private IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator;
		private IBOLCountryRegionCurrencyMapper countryRegionCurrencyMapper;
		private ILogger logger;

		public AbstractBOCountryRegionCurrency(
			ILogger logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
			IBOLCountryRegionCurrencyMapper countryRegionCurrencyMapper)
			: base()

		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
			this.countryRegionCurrencyMapper = countryRegionCurrencyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryRegionCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.countryRegionCurrencyRepository.All(skip, take, orderClause);

			return this.countryRegionCurrencyMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode)
		{
			var record = await countryRegionCurrencyRepository.Get(countryRegionCode);

			return this.countryRegionCurrencyMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
			ApiCountryRegionCurrencyRequestModel model)
		{
			CreateResponse<ApiCountryRegionCurrencyResponseModel> response = new CreateResponse<ApiCountryRegionCurrencyResponseModel>(await this.countryRegionCurrencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.countryRegionCurrencyMapper.MapModelToDTO(default (string), model);
				var record = await this.countryRegionCurrencyRepository.Create(dto);

				response.SetRecord(this.countryRegionCurrencyMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateUpdateAsync(countryRegionCode, model));

			if (response.Success)
			{
				var dto = this.countryRegionCurrencyMapper.MapModelToDTO(countryRegionCode, model);
				await this.countryRegionCurrencyRepository.Update(countryRegionCode, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				await this.countryRegionCurrencyRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public async Task<List<ApiCountryRegionCurrencyResponseModel>> GetCurrencyCode(string currencyCode)
		{
			List<DTOCountryRegionCurrency> records = await this.countryRegionCurrencyRepository.GetCurrencyCode(currencyCode);

			return this.countryRegionCurrencyMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e5113fb7d6203140233128b04f99721a</Hash>
</Codenesium>*/