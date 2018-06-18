using Moq;
using System;
using System.Collections.Generic;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Services.Tests
{
        public class DALMapperMockFactory
        {
                public IDALDeviceMapper DALDeviceMapperMock { get; set; } = new DALDeviceMapper();

                public IDALDeviceActionMapper DALDeviceActionMapperMock { get; set; } = new DALDeviceActionMapper();

                public DALMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3e5244d15d61dddb94e3c6fc0bb60a10</Hash>
</Codenesium>*/