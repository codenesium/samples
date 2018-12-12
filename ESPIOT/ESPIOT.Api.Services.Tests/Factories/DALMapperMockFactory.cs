using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALEfmigrationshistoryMapper DALEfmigrationshistoryMapperMock { get; set; } = new DALEfmigrationshistoryMapper();

		public IDALDeviceMapper DALDeviceMapperMock { get; set; } = new DALDeviceMapper();

		public IDALDeviceActionMapper DALDeviceActionMapperMock { get; set; } = new DALDeviceActionMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>50fadca34208370b375d51181264d38d</Hash>
</Codenesium>*/