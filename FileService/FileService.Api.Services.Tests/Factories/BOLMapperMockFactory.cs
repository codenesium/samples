using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Moq;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLBucketMapper BOLBucketMapperMock { get; set; } = new BOLBucketMapper();

		public IBOLFileMapper BOLFileMapperMock { get; set; } = new BOLFileMapper();

		public IBOLFileTypeMapper BOLFileTypeMapperMock { get; set; } = new BOLFileTypeMapper();

		public IBOLVersionInfoMapper BOLVersionInfoMapperMock { get; set; } = new BOLVersionInfoMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>89c5e31b9e24f343908c65a96da44c82</Hash>
</Codenesium>*/