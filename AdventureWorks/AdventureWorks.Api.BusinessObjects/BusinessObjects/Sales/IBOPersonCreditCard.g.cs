using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPersonCreditCard
	{
		Task<CreateResponse<POCOPersonCreditCard>> Create(
			ApiPersonCreditCardModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonCreditCardModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOPersonCreditCard> Get(int businessEntityID);

		Task<List<POCOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>35a572693a06e1d71094647ccdc2e473</Hash>
</Codenesium>*/