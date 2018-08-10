using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBusinessEntityContactService
	{
		Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model);

		Task<UpdateResponse<ApiBusinessEntityContactResponseModel>> Update(int businessEntityID,
		                                                                    ApiBusinessEntityContactRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID);

		Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>dc2e8d731fe4a9a9f7bc3f47344a93b1</Hash>
</Codenesium>*/