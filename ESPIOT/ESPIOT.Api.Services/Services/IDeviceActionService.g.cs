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

                Task<List<ApiDeviceActionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId);
        }
}

/*<Codenesium>
    <Hash>09a83f25638f43dcefb76c1831d47df2</Hash>
</Codenesium>*/