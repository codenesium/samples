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
	public abstract class AbstractBOCreditCard
	{
		private ICreditCardRepository creditCardRepository;
		private ICreditCardModelValidator creditCardModelValidator;
		private ILogger logger;

		public AbstractBOCreditCard(
			ILogger logger,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator)

		{
			this.creditCardRepository = creditCardRepository;
			this.creditCardModelValidator = creditCardModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			CreditCardModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.creditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.creditCardRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int creditCardID,
			CreditCardModel model)
		{
			ActionResponse response = new ActionResponse(await this.creditCardModelValidator.ValidateUpdateAsync(creditCardID, model));

			if (response.Success)
			{
				this.creditCardRepository.Update(creditCardID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int creditCardID)
		{
			ActionResponse response = new ActionResponse(await this.creditCardModelValidator.ValidateDeleteAsync(creditCardID));

			if (response.Success)
			{
				this.creditCardRepository.Delete(creditCardID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int creditCardID)
		{
			return this.creditCardRepository.GetById(creditCardID);
		}

		public virtual POCOCreditCard GetByIdDirect(int creditCardID)
		{
			return this.creditCardRepository.GetByIdDirect(creditCardID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.creditCardRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.creditCardRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.creditCardRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>14ee06b6fa6f56bc8c1a7a2cb9d059d5</Hash>
</Codenesium>*/