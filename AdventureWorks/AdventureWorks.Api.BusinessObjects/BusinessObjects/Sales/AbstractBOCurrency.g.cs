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
		private ICurrencyModelValidator currencyModelValidator;
		private ILogger logger;

		public AbstractBOCurrency(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			ICurrencyModelValidator currencyModelValidator)

		{
			this.currencyRepository = currencyRepository;
			this.currencyModelValidator = currencyModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<string>> Create(
			CurrencyModel model)
		{
			CreateResponse<string> response = new CreateResponse<string>(await this.currencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				string id = this.currencyRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string currencyCode,
			CurrencyModel model)
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

		public virtual POCOCurrency Get(string currencyCode)
		{
			return this.currencyRepository.Get(currencyCode);
		}

		public virtual List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>b5c1d85b73cfb9c3d90010dbddea7da2</Hash>
</Codenesium>*/