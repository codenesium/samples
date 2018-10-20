using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBusinessEntityService
	{
		Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model);

		Task<UpdateResponse<ApiBusinessEntityResponseModel>> Update(int businessEntityID,
		                                                             ApiBusinessEntityRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonResponseModel>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8be802b00c799b0a4cf7a4e66252b81b</Hash>
</Codenesium>*/