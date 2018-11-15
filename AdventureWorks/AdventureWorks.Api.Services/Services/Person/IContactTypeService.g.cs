using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IContactTypeService
	{
		Task<CreateResponse<ApiContactTypeServerResponseModel>> Create(
			ApiContactTypeServerRequestModel model);

		Task<UpdateResponse<ApiContactTypeServerResponseModel>> Update(int contactTypeID,
		                                                                ApiContactTypeServerRequestModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<ApiContactTypeServerResponseModel> Get(int contactTypeID);

		Task<List<ApiContactTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiContactTypeServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>dcb5d840731b429ede3149edd82b19fe</Hash>
</Codenesium>*/