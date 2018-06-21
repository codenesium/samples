using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
        public interface IBOLDeviceMapper
        {
                BODevice MapModelToBO(
                        int id,
                        ApiDeviceRequestModel model);

                ApiDeviceResponseModel MapBOToModel(
                        BODevice boDevice);

                List<ApiDeviceResponseModel> MapBOToModel(
                        List<BODevice> items);
        }
}

/*<Codenesium>
    <Hash>f55033fb2e5570ef0546c90b9cfe1233</Hash>
</Codenesium>*/