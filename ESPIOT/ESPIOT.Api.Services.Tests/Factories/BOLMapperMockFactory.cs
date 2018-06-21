using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

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
    <Hash>857deb2e4495d542c284fde0208b8778</Hash>
</Codenesium>*/