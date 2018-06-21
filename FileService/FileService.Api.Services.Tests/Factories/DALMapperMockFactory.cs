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
    <Hash>a2562149db3c3ff6c257913f3239e32c</Hash>
</Codenesium>*/