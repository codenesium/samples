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
		Task<CreateResponse<POCOSpecialOffer>> Create(
			ApiSpecialOfferModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            ApiSpecialOfferModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		POCOSpecialOffer Get(int specialOfferID);

		List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4499e8e767fe465c87a5604dad8e14ba</Hash>
</Codenesium>*/