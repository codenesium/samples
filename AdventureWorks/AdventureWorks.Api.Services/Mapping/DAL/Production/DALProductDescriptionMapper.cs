using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductDescriptionMapper : DALAbstractProductDescriptionMapper, IDALProductDescriptionMapper
        {
                public DALProductDescriptionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>869fb6fbf1b6f0646745f815fc5e2d74</Hash>
</Codenesium>*/