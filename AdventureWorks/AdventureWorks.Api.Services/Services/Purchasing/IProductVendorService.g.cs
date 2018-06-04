using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductVendorService
	{
		Task<CreateResponse<ApiProductVendorResponseModel>> Create(
			ApiProductVendorRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductVendorRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductVendorResponseModel> Get(int productID);

		Task<List<ApiProductVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiProductVendorResponseModel>> GetBusinessEntityID(int businessEntityID);
		Task<List<ApiProductVendorResponseModel>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>e807138eadd97869393f8102542ddec4</Hash>
</Codenesium>*/