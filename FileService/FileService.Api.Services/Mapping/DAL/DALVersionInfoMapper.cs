using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
        public partial class DALVersionInfoMapper : DALAbstractVersionInfoMapper, IDALVersionInfoMapper
        {
                public DALVersionInfoMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>59a2e5006b4728eca13c95067c5a120f</Hash>
</Codenesium>*/