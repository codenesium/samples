using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IFeedService
	{
		Task<CreateResponse<ApiFeedResponseModel>> Create(
			ApiFeedRequestModel model);

		Task<UpdateResponse<ApiFeedResponseModel>> Update(string id,
		                                                   ApiFeedRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiFeedResponseModel> Get(string id);

		Task<List<ApiFeedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiFeedResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>829835abcfb5f9e17cb53e176999eb0f</Hash>
</Codenesium>*/