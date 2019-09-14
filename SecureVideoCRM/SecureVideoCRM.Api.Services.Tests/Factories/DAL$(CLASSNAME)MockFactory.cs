using Moq;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALVideoMapper DALVideoMapperMock { get; set; } = new DALVideoMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public IDALSubscriptionMapper DALSubscriptionMapperMock { get; set; } = new DALSubscriptionMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e79129eeff3be76193608c5522625b23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/