using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
        public interface IBOLDeviceActionMapper
        {
                BODeviceAction MapModelToBO(
                        int id,
                        ApiDeviceActionRequestModel model);

                ApiDeviceActionResponseModel MapBOToModel(
                        BODeviceAction boDeviceAction);

                List<ApiDeviceActionResponseModel> MapBOToModel(
                        List<BODeviceAction> items);
        }
}

/*<Codenesium>
    <Hash>4531565b55823a909da689f03490a194</Hash>
</Codenesium>*/