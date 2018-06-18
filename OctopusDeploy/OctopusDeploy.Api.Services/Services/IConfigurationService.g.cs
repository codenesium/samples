using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>3949a267117bfde86194a5f034d38b31</Hash>
</Codenesium>*/