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
	public abstract class AbstractBOPersonCreditCard
	{
		private IPersonCreditCardRepository personCreditCardRepository;
		private IPersonCreditCardModelValidator personCreditCardModelValidator;
		private ILogger logger;

		public AbstractBOPersonCreditCard(
			ILogger logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator)

		{
			this.personCreditCardRepository = personCreditCardRepository;
			this.personCreditCardModelValidator = personCreditCardModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PersonCreditCardModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.personCreditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.personCreditCardRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			PersonCreditCardModel model)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.personCreditCardRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.personCreditCardRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOPersonCreditCard Get(int businessEntityID)
		{
			return this.personCreditCardRepository.Get(businessEntityID);
		}

		public virtual List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personCreditCardRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2f90adea80f1e8f2edd24866ce899050</Hash>
</Codenesium>*/