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

                Task<List<ApiConfigurationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>5bdceffb53724b47883e6a897c2fdb3e</Hash>
</Codenesium>*/