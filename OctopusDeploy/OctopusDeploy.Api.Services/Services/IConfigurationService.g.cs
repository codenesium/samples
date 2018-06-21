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

                Task<ActionResponse> Update(string id,
                                            ApiConfigurationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiConfigurationResponseModel> Get(string id);

                Task<List<ApiConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2e96a0affe65475a5da6c61b9a65180c</Hash>
</Codenesium>*/