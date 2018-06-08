using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALDepartmentMapper: DALAbstractDepartmentMapper, IDALDepartmentMapper
        {
                public DALDepartmentMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a272fdcc296fdfdb496b5a0bd36a8a1c</Hash>
</Codenesium>*/