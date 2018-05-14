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
		Task<CreateResponse<POCOCreditCard>> Create(
			ApiCreditCardModel model);

		Task<ActionResponse> Update(int creditCardID,
		                            ApiCreditCardModel model);

		Task<ActionResponse> Delete(int creditCardID);

		POCOCreditCard Get(int creditCardID);

		List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCreditCard GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>70f91960c50d46d902fd02c412776f21</Hash>
</Codenesium>*/