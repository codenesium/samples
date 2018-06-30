using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface INuGetPackageService
        {
                Task<CreateResponse<ApiNuGetPackageResponseModel>> Create(
                        ApiNuGetPackageRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiNuGetPackageRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiNuGetPackageResponseModel> Get(string id);

                Task<List<ApiNuGetPackageResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>af1d39309e14ce738e86f97b5820e554</Hash>
</Codenesium>*/