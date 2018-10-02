using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkStatuService
	{
		Task<CreateResponse<ApiLinkStatuResponseModel>> Create(
			ApiLinkStatuRequestModel model);

		Task<UpdateResponse<ApiLinkStatuResponseModel>> Update(int id,
		                                                        ApiLinkStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkStatuResponseModel> Get(int id);

		Task<List<ApiLinkStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLinkStatuResponseModel> ByName(string name);

		Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>172d633875c700a821a0368bf403adab</Hash>
</Codenesium>*/