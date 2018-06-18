using Moq;
using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services.Tests
{
        public class BOLMapperMockFactory
        {
                public IBOLDeviceMapper BOLDeviceMapperMock { get; set; } = new BOLDeviceMapper();

                public IBOLDeviceActionMapper BOLDeviceActionMapperMock { get; set; } = new BOLDeviceActionMapper();

                public BOLMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa05846fabfe975075e730d80bceb560</Hash>
</Codenesium>*/