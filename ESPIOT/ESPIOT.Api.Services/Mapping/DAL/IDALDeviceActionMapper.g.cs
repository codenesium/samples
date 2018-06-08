using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

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
    <Hash>ddaf2c23549393f9de575e771ad16aa8</Hash>
</Codenesium>*/