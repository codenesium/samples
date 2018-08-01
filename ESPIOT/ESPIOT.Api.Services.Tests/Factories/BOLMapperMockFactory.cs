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
    <Hash>e73d6b4efb3f843b8f7c92f4d0ff0391</Hash>
</Codenesium>*/