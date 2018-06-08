using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

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
    <Hash>25d4bc1e10851467942f47655537eeb7</Hash>
</Codenesium>*/