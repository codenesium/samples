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
    <Hash>d7685d8aa6a9034f4c31c047769d9973</Hash>
</Codenesium>*/