using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

namespace ESPIOTPostgresNS.Api.Services.Tests
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
    <Hash>eac26876fa72734356bd875a3a52ec81</Hash>
</Codenesium>*/