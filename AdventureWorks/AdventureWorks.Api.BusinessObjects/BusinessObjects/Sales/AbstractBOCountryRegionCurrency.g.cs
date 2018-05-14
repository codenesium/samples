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
	public abstract class AbstractBOCountryRegionCurrency
	{
		private ICountryRegionCurrencyRepository countryRegionCurrencyRepository;
		private IApiCountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator;
		private ILogger logger;

		public AbstractBOCountryRegionCurrency(
			ILogger logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator)

		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionCurrencyRepository.All(skip, take, orderClause);
		}

		public virtual POCOCountryRegionCurrency Get(string countryRegionCode)
		{
			return this.countryRegionCurrencyRepository.Get(countryRegionCode);
		}

		public virtual async Task<CreateResponse<POCOCountryRegionCurrency>> Create(
			ApiCountryRegionCurrencyModel model)
		{
			CreateResponse<POCOCountryRegionCurrency> response = new CreateResponse<POCOCountryRegionCurrency>(await this.countryRegionCurrencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountryRegionCurrency record = this.countryRegionCurrencyRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			ApiCountryRegionCurrencyModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateUpdateAsync(countryRegionCode, model));

			if (response.Success)
			{
				this.countryRegionCurrencyRepository.Update(countryRegionCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionCurrencyModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				this.countryRegionCurrencyRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public List<POCOCountryRegionCurrency> GetCurrencyCode(string currencyCode)
		{
			return this.countryRegionCurrencyRepository.GetCurrencyCode(currencyCode);
		}
	}
}

/*<Codenesium>
    <Hash>5450d932f0314adecbb6225c96f31b10</Hash>
</Codenesium>*/