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
		private IApiCreditCardModelValidator creditCardModelValidator;
		private ILogger logger;

		public AbstractBOCreditCard(
			ILogger logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardModelValidator creditCardModelValidator)

		{
			this.creditCardRepository = creditCardRepository;
			this.creditCardModelValidator = creditCardModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.creditCardRepository.All(skip, take, orderClause);
		}

		public virtual POCOCreditCard Get(int creditCardID)
		{
			return this.creditCardRepository.Get(creditCardID);
		}

		public virtual async Task<CreateResponse<POCOCreditCard>> Create(
			ApiCreditCardModel model)
		{
			CreateResponse<POCOCreditCard> response = new CreateResponse<POCOCreditCard>(await this.creditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCreditCard record = this.creditCardRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int creditCardID,
			ApiCreditCardModel model)
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

		public POCOCreditCard GetCardNumber(string cardNumber)
		{
			return this.creditCardRepository.GetCardNumber(cardNumber);
		}
	}
}

/*<Codenesium>
    <Hash>762882ecf39a9aad73cb7d74f6024c89</Hash>
</Codenesium>*/