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
    <Hash>16f9b741d24932602ab678409cd0b94f</Hash>
</Codenesium>*/