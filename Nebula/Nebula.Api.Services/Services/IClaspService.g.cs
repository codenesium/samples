using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IClaspService
	{
		Task<CreateResponse<ApiClaspServerResponseModel>> Create(
			ApiClaspServerRequestModel model);

		Task<UpdateResponse<ApiClaspServerResponseModel>> Update(int id,
		                                                          ApiClaspServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClaspServerResponseModel> Get(int id);

		Task<List<ApiClaspServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8fc42d373c4f663a8dc3e525d591c8a3</Hash>
</Codenesium>*/