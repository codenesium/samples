using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALDepartmentMapper : DALAbstractDepartmentMapper, IDALDepartmentMapper
        {
                public DALDepartmentMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>83312c933b2827978d6163aead89452d</Hash>
</Codenesium>*/