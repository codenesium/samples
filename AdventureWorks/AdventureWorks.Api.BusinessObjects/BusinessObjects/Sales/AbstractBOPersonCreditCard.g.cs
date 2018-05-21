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
	public abstract class AbstractBOPersonCreditCard: AbstractBOManager
	{
		private IPersonCreditCardRepository personCreditCardRepository;
		private IApiPersonCreditCardModelValidator personCreditCardModelValidator;
		private ILogger logger;

		public AbstractBOPersonCreditCard(
			ILogger logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardModelValidator personCreditCardModelValidator)
			: base()

		{
			this.personCreditCardRepository = personCreditCardRepository;
			this.personCreditCardModelValidator = personCreditCardModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personCreditCardRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPersonCreditCard> Get(int businessEntityID)
		{
			return this.personCreditCardRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOPersonCreditCard>> Create(
			ApiPersonCreditCardModel model)
		{
			CreateResponse<POCOPersonCreditCard> response = new CreateResponse<POCOPersonCreditCard>(await this.personCreditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPersonCreditCard record = await this.personCreditCardRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonCreditCardModel model)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.personCreditCardRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.personCreditCardRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59022b03f7c4176108aad82f484d253b</Hash>
</Codenesium>*/