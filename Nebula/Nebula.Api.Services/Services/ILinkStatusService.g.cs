using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkStatusService
	{
		Task<CreateResponse<ApiLinkStatusServerResponseModel>> Create(
			ApiLinkStatusServerRequestModel model);

		Task<UpdateResponse<ApiLinkStatusServerResponseModel>> Update(int id,
		                                                               ApiLinkStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkStatusServerResponseModel> Get(int id);

		Task<List<ApiLinkStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiLinkStatusServerResponseModel> ByName(string name);

		Task<List<ApiLinkServerResponseModel>> LinksByLinkStatusId(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>282abb3e2608a8a21b2c4f168eb89cad</Hash>
</Codenesium>*/