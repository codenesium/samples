using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCountryRegionMapper : DALAbstractCountryRegionMapper, IDALCountryRegionMapper
        {
                public DALCountryRegionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9fd41a071da60fbc0251d9a272eff4b2</Hash>
</Codenesium>*/