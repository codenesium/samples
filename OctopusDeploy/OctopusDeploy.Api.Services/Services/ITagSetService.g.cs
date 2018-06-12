using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ITagSetService
        {
                Task<CreateResponse<ApiTagSetResponseModel>> Create(
                        ApiTagSetRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiTagSetRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTagSetResponseModel> Get(string id);

                Task<List<ApiTagSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiTagSetResponseModel> GetName(string name);
                Task<List<ApiTagSetResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>303993bb624bd0c47c196fe09b06e0e0</Hash>
</Codenesium>*/