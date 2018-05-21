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
		Task<CreateResponse<POCOSpecialOfferProduct>> Create(
			ApiSpecialOfferProductModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            ApiSpecialOfferProductModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<POCOSpecialOfferProduct> Get(int specialOfferID);

		Task<List<POCOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOSpecialOfferProduct>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>d02be8d7908f29ca5c028ae5c32633c2</Hash>
</Codenesium>*/