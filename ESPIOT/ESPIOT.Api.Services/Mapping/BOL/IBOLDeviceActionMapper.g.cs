using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

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
    <Hash>f21ebdf2f59aa86de0925b196532ff3d</Hash>
</Codenesium>*/