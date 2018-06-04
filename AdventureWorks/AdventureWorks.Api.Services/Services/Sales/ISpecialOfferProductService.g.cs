using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISpecialOfferProductService
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
    <Hash>fa4e15cec4fed34f99f14cffa41376f4</Hash>
</Codenesium>*/