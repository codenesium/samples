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

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>51713d25aebea0ac5fa9e490ec375150</Hash>
</Codenesium>*/