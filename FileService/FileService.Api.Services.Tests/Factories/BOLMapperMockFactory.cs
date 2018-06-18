using Moq;
using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

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
    <Hash>96fcb9fd8ee44c1d39e902a22021d6d0</Hash>
</Codenesium>*/