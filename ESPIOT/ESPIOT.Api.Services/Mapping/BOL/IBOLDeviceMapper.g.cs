using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

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
    <Hash>28c7fe6a03753c281657cd5aba56f917</Hash>
</Codenesium>*/