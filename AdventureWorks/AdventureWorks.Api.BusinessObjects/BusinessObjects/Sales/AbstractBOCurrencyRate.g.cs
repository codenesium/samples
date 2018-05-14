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
		private IApiCurrencyRateModelValidator currencyRateModelValidator;
		private ILogger logger;

		public AbstractBOCurrencyRate(
			ILogger logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateModelValidator currencyRateModelValidator)

		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRateRepository.All(skip, take, orderClause);
		}

		public virtual POCOCurrencyRate Get(int currencyRateID)
		{
			return this.currencyRateRepository.Get(currencyRateID);
		}

		public virtual async Task<CreateResponse<POCOCurrencyRate>> Create(
			ApiCurrencyRateModel model)
		{
			CreateResponse<POCOCurrencyRate> response = new CreateResponse<POCOCurrencyRate>(await this.currencyRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCurrencyRate record = this.currencyRateRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int currencyRateID,
			ApiCurrencyRateModel model)
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

		public POCOCurrencyRate GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			return this.currencyRateRepository.GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate,fromCurrencyCode,toCurrencyCode);
		}
	}
}

/*<Codenesium>
    <Hash>a8cb572adce3196fa4703cd8afce98a0</Hash>
</Codenesium>*/