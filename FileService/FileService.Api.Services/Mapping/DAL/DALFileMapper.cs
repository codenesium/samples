using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
        public class DALFileMapper : DALAbstractFileMapper, IDALFileMapper
        {
                public DALFileMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>88a24c16966b8625ab18e0025b22453f</Hash>
</Codenesium>*/