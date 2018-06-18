using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>9609ad2e8d1538b584ef3eddfc47e95c</Hash>
</Codenesium>*/