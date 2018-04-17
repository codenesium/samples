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

		public virtual ApiResponse GetById(string currencyCode)
		{
			return this.currencyRepository.GetById(currencyCode);
		}

		public virtual POCOCurrency GetByIdDirect(string currencyCode)
		{
			return this.currencyRepository.GetByIdDirect(currencyCode);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.currencyRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>0ef2e3df313bc01c402bd19c6c664ce2</Hash>
</Codenesium>*/