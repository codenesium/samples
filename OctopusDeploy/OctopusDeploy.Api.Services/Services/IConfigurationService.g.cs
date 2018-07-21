using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IConfigurationService
        {
                Task<CreateResponse<ApiConfigurationResponseModel>> Create(
                        ApiConfigurationRequestModel model);

                Task<UpdateResponse<ApiConfigurationResponseModel>> Update(string id,
                                                                            ApiConfigurationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiConfigurationResponseModel> Get(string id);

                Task<List<ApiConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ba106ef2f90c8e672956c4ebf21b2d39</Hash>
</Codenesium>*/