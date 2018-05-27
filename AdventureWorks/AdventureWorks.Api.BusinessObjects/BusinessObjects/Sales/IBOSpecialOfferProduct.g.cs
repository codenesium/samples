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
		Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            ApiSpecialOfferProductRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiSpecialOfferProductResponseModel>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>19eafad5a0d4066b05dc5cf4e23ca960</Hash>
</Codenesium>*/