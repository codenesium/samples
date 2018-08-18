using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IFeedService
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
    <Hash>f954c289b6ec7a7853ae990331eac20c</Hash>
</Codenesium>*/