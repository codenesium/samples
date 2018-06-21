using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
        public interface IDALDeviceActionMapper
        {
                DeviceAction MapBOToEF(
                        BODeviceAction bo);

                BODeviceAction MapEFToBO(
                        DeviceAction efDeviceAction);

                List<BODeviceAction> MapEFToBO(
                        List<DeviceAction> records);
        }
}

/*<Codenesium>
    <Hash>54a2c32a7211bd75d077e203c7d406cd</Hash>
</Codenesium>*/