using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public interface IDeviceActionService
        {
                Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
                        ApiDeviceActionRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiDeviceActionRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDeviceActionResponseModel> Get(int id);

                Task<List<ApiDeviceActionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiDeviceActionResponseModel>> GetDeviceId(int deviceId);
        }
}

/*<Codenesium>
    <Hash>b94f0c8c51c53d12214413bbb75c6aad</Hash>
</Codenesium>*/