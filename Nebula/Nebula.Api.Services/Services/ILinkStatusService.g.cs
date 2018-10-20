using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkStatusService
	{
		Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
			ApiLinkStatusRequestModel model);

		Task<UpdateResponse<ApiLinkStatusResponseModel>> Update(int id,
		                                                         ApiLinkStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkStatusResponseModel> Get(int id);

		Task<List<ApiLinkStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLinkStatusResponseModel> ByName(string name);

		Task<List<ApiLinkResponseModel>> LinksByLinkStatusId(int linkStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4e23afc03c379818a76a1c630c6e9b5a</Hash>
</Codenesium>*/