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

		POCOSpecialOfferProduct Get(int specialOfferID);

		List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>c464c1f59c3297d7dd494928b4ccc67d</Hash>
</Codenesium>*/