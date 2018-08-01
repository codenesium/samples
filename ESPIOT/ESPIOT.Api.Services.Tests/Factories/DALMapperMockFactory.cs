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
    <Hash>928a60ed007203c24d979ce256e9ae0a</Hash>
</Codenesium>*/