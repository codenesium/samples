using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;

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
    <Hash>8da770b8fb9122f29ea2e476a79f9fd0</Hash>
</Codenesium>*/