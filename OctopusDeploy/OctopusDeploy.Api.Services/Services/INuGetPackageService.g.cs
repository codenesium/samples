using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface INuGetPackageService
	{
		Task<CreateResponse<ApiNuGetPackageResponseModel>> Create(
			ApiNuGetPackageRequestModel model);

		Task<UpdateResponse<ApiNuGetPackageResponseModel>> Update(string id,
		                                                           ApiNuGetPackageRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiNuGetPackageResponseModel> Get(string id);

		Task<List<ApiNuGetPackageResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>73cf7fd95791829c6f30bc4011c50601</Hash>
</Codenesium>*/