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
	public abstract class AbstractBOCurrencyRate
	{
		private ICurrencyRateRepository currencyRateRepository;
		private ICurrencyRateModelValidator currencyRateModelValidator;
		private ILogger logger;

		public AbstractBOCurrencyRate(
			ILogger logger,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator)

		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			CurrencyRateModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.currencyRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.currencyRateRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int currencyRateID,
			CurrencyRateModel model)
		{
			ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateUpdateAsync(currencyRateID, model));

			if (response.Success)
			{
				this.currencyRateRepository.Update(currencyRateID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int currencyRateID)
		{
			ActionResponse response = new ActionResponse(await this.currencyRateModelValidator.ValidateDeleteAsync(currencyRateID));

			if (response.Success)
			{
				this.currencyRateRepository.Delete(currencyRateID);
			}
			return response;
		}

		public virtual POCOCurrencyRate Get(int currencyRateID)
		{
			return this.currencyRateRepository.Get(currencyRateID);
		}

		public virtual List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRateRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>57769ec6fedde46e07213c40623e1ee6</Hash>
</Codenesium>*/