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

		public virtual ApiResponse GetById(int currencyRateID)
		{
			return this.currencyRateRepository.GetById(currencyRateID);
		}

		public virtual POCOCurrencyRate GetByIdDirect(int currencyRateID)
		{
			return this.currencyRateRepository.GetByIdDirect(currencyRateID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRateRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRateRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRateRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>b5bc4b9d892f98d16139b7809ae3368c</Hash>
</Codenesium>*/