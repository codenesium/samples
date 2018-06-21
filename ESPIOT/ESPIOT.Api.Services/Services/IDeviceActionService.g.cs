using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>5f550184e5c98299ec2789616eb5f770</Hash>
</Codenesium>*/