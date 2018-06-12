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

                Task<List<ApiNuGetPackageResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>977ad6e507916bcb955519e5131e7123</Hash>
</Codenesium>*/