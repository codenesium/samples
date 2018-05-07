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
		Task<CreateResponse<int>> Create(
			PersonCreditCardModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PersonCreditCardModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPersonCreditCard Get(int businessEntityID);

		List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e140b343f2e923227aafc020cdc8954e</Hash>
</Codenesium>*/