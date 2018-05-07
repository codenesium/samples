using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSpecialOffer
	{
		Task<CreateResponse<int>> Create(
			SpecialOfferModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            SpecialOfferModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		POCOSpecialOffer Get(int specialOfferID);

		List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>33fdb40ce3199a22405682e0bd5eec82</Hash>
</Codenesium>*/