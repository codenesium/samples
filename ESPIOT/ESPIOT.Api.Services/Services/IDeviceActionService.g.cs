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

                Task<List<ApiDeviceActionResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId);
        }
}

/*<Codenesium>
    <Hash>2d3ddb11c2463176eac653cf7d6c256d</Hash>
</Codenesium>*/