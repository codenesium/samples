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

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5fc6e0f39c14026b650bd35b284f5cbc</Hash>
</Codenesium>*/