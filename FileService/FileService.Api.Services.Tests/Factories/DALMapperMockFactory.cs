using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALBucketMapper DALBucketMapperMock { get; set; } = new DALBucketMapper();

		public IDALFileMapper DALFileMapperMock { get; set; } = new DALFileMapper();

		public IDALFileTypeMapper DALFileTypeMapperMock { get; set; } = new DALFileTypeMapper();

		public IDALVersionInfoMapper DALVersionInfoMapperMock { get; set; } = new DALVersionInfoMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>fcaa6d538e3c48e7a358e2c477551561</Hash>
</Codenesium>*/