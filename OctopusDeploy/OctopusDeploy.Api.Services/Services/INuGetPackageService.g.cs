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

                Task<List<ApiNuGetPackageResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f037f6f0a7d4bb0a9294706a098ef87f</Hash>
</Codenesium>*/