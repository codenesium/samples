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
		private ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator;
		private ILogger logger;

		public AbstractBOCountryRegionCurrency(
			ILogger logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator)

		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<string>> Create(
			CountryRegionCurrencyModel model)
		{
			CreateResponse<string> response = new CreateResponse<string>(await this.countryRegionCurrencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				string id = this.countryRegionCurrencyRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			CountryRegionCurrencyModel model)
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

		public virtual POCOCountryRegionCurrency Get(string countryRegionCode)
		{
			return this.countryRegionCurrencyRepository.Get(countryRegionCode);
		}

		public virtual List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionCurrencyRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4ff04a9f2bf258d41b9ed03c6a95a4cd</Hash>
</Codenesium>*/