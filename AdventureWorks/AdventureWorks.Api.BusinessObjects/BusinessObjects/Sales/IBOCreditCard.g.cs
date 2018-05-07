using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCreditCard
	{
		Task<CreateResponse<int>> Create(
			CreditCardModel model);

		Task<ActionResponse> Update(int creditCardID,
		                            CreditCardModel model);

		Task<ActionResponse> Delete(int creditCardID);

		POCOCreditCard Get(int creditCardID);

		List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8e42c2aa014d060412e5e6ccfc6e74df</Hash>
</Codenesium>*/