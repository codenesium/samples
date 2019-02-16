using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
    <Hash>b0f140d437f3c4a01a348151739b2c92</Hash>
</Codenesium>*/