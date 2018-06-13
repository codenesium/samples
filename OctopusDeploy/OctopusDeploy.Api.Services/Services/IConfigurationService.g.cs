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

                Task<List<ApiConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f0b659869ae5eb9c5d01440db647b56d</Hash>
</Codenesium>*/