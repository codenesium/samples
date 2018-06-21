using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
        public interface IDALDeviceMapper
        {
                Device MapBOToEF(
                        BODevice bo);

                BODevice MapEFToBO(
                        Device efDevice);

                List<BODevice> MapEFToBO(
                        List<Device> records);
        }
}

/*<Codenesium>
    <Hash>2c88cc986d6618362324eb18f598f2a5</Hash>
</Codenesium>*/