using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBusinessEntityService
	{
		Task<CreateResponse<ApiBusinessEntityServerResponseModel>> Create(
			ApiBusinessEntityServerRequestModel model);

		Task<UpdateResponse<ApiBusinessEntityServerResponseModel>> Update(int businessEntityID,
		                                                                   ApiBusinessEntityServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityServerResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiBusinessEntityServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiPersonServerResponseModel>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>98ebc3e1479ee3372456fa77577d5711</Hash>
</Codenesium>*/