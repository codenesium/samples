using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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
    <Hash>c2efa2d62235893173b1f637d97cf138</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/