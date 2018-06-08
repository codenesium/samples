using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALShiftMapper: DALAbstractShiftMapper, IDALShiftMapper
        {
                public DALShiftMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>379bc86d1a81dcd4f4f281a7efd778cb</Hash>
</Codenesium>*/