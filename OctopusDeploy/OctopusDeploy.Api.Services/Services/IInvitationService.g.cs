using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IInvitationService
	{
		Task<CreateResponse<ApiInvitationResponseModel>> Create(
			ApiInvitationRequestModel model);

		Task<UpdateResponse<ApiInvitationResponseModel>> Update(string id,
		                                                         ApiInvitationRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiInvitationResponseModel> Get(string id);

		Task<List<ApiInvitationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e51db9eb7735db38c4d74f48434fea33</Hash>
</Codenesium>*/