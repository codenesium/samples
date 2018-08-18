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
    <Hash>4afa7ec6e5ef2f5b59bca8b4bcd6e779</Hash>
</Codenesium>*/