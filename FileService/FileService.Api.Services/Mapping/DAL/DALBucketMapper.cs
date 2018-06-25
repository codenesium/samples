using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
        public partial class DALBucketMapper : DALAbstractBucketMapper, IDALBucketMapper
        {
                public DALBucketMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>19e5ca1d8a18fbe0a9c115e8e75bd21a</Hash>
</Codenesium>*/