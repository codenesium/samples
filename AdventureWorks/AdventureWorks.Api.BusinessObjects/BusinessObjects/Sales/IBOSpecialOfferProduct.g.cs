using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSpecialOfferProduct
	{
		Task<CreateResponse<int>> Create(
			SpecialOfferProductModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            SpecialOfferProductModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		POCOSpecialOfferProduct Get(int specialOfferID);

		List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8cfc7053e9cec09219a0d5ee4ede037f</Hash>
</Codenesium>*/