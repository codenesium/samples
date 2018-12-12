using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLEfmigrationshistoryMapper BOLEfmigrationshistoryMapperMock { get; set; } = new BOLEfmigrationshistoryMapper();

		public IBOLDeviceMapper BOLDeviceMapperMock { get; set; } = new BOLDeviceMapper();

		public IBOLDeviceActionMapper BOLDeviceActionMapperMock { get; set; } = new BOLDeviceActionMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>90bcaac0dc8975297eb90809f9d85e42</Hash>
</Codenesium>*/