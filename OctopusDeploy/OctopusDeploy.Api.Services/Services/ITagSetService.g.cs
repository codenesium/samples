using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiTagSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTagSetResponseModel> GetName(string name);

                Task<List<ApiTagSetResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>ebe4e679efebd065e7cf166923fa57fd</Hash>
</Codenesium>*/