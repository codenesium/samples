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
	public abstract class AbstractBOCurrency
	{
		private ICurrencyRepository currencyRepository;
		private IApiCurrencyModelValidator currencyModelValidator;
		private ILogger logger;

		public AbstractBOCurrency(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyModelValidator currencyModelValidator)

		{
			this.currencyRepository = currencyRepository;
			this.currencyModelValidator = currencyModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRepository.All(skip, take, orderClause);
		}

		public virtual POCOCurrency Get(string currencyCode)
		{
			return this.currencyRepository.Get(currencyCode);
		}

		public virtual async Task<CreateResponse<POCOCurrency>> Create(
			ApiCurrencyModel model)
		{
			CreateResponse<POCOCurrency> response = new CreateResponse<POCOCurrency>(await this.currencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCurrency record = this.currencyRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string currencyCode,
			ApiCurrencyModel model)
		{
			ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateUpdateAsync(currencyCode, model));

			if (response.Success)
			{
				this.currencyRepository.Update(currencyCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string currencyCode)
		{
			ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateDeleteAsync(currencyCode));

			if (response.Success)
			{
				this.currencyRepository.Delete(currencyCode);
			}
			return response;
		}

		public POCOCurrency GetName(string name)
		{
			return this.currencyRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>c7e9a3ecdf15668bf88df3170ab0ca59</Hash>
</Codenesium>*/