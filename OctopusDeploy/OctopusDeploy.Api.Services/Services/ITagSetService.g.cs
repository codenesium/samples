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

                Task<List<ApiTagSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTagSetResponseModel> GetName(string name);
                Task<List<ApiTagSetResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>3164ac4ce01eca39026da52a62dc239b</Hash>
</Codenesium>*/