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

		Task<POCOSpecialOffer> Get(int specialOfferID);

		Task<List<POCOSpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f8687ce4cbf59a288be0d4c182fad109</Hash>
</Codenesium>*/