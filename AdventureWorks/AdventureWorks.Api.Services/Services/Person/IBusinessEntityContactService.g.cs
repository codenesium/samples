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

		Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>872f279ddc40f439d7f9720c957110cb</Hash>
</Codenesium>*/