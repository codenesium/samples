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

		POCOPersonCreditCard Get(int businessEntityID);

		List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>35bedcb632aa4e25d8a5c590b7a6a83e</Hash>
</Codenesium>*/