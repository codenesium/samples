using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductDescriptionMapper : DALAbstractProductDescriptionMapper, IDALProductDescriptionMapper
        {
                public DALProductDescriptionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>30dfa63e5b16fab6f7ca1e8124c98f90</Hash>
</Codenesium>*/