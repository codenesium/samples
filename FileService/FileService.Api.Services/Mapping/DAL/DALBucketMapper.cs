using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class DALBucketMapper: DALAbstractBucketMapper, IDALBucketMapper
        {
                public DALBucketMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5fa258c6e09cd9a4eca20d5109720fdf</Hash>
</Codenesium>*/