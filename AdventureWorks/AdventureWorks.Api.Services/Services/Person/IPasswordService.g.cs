using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPasswordService
	{
		Task<CreateResponse<ApiPasswordServerResponseModel>> Create(
			ApiPasswordServerRequestModel model);

		Task<UpdateResponse<ApiPasswordServerResponseModel>> Update(int businessEntityID,
		                                                             ApiPasswordServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPasswordServerResponseModel> Get(int businessEntityID);

		Task<List<ApiPasswordServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>de148d96b774a0d86eb90e59a61ad5b4</Hash>
</Codenesium>*/