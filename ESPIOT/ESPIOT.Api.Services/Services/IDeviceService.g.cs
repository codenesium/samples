using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public interface IDeviceService
        {
                Task<CreateResponse<ApiDeviceResponseModel>> Create(
                        ApiDeviceRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiDeviceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDeviceResponseModel> Get(int id);

                Task<List<ApiDeviceResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiDeviceResponseModel> ByPublicId(Guid publicId);

                Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e7f168690b2063170ea3aae2cb380d93</Hash>
</Codenesium>*/