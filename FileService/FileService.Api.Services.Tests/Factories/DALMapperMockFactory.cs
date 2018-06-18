using Moq;
using System;
using System.Collections.Generic;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

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
    <Hash>7bb81c25faca1904824c1efdfbd11410</Hash>
</Codenesium>*/