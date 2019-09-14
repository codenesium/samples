using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IProductService
	{
		Task<CreateResponse<ApiProductServerResponseModel>> Create(
			ApiProductServerRequestModel model);

		Task<UpdateResponse<ApiProductServerResponseModel>> Update(int id,
		                                                            ApiProductServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiProductServerResponseModel> Get(int id);

		Task<List<ApiProductServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>8f781838574a6ed13dd2912500dbce89</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/