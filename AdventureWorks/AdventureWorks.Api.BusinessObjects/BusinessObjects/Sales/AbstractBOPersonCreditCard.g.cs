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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.personCreditCardRepository.GetById(businessEntityID);
		}

		public virtual POCOPersonCreditCard GetByIdDirect(int businessEntityID)
		{
			return this.personCreditCardRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personCreditCardRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personCreditCardRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personCreditCardRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5c1c33d92cc46b37f059b95c84dc5771</Hash>
</Codenesium>*/