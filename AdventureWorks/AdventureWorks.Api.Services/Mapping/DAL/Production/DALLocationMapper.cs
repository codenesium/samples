using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALLocationMapper : DALAbstractLocationMapper, IDALLocationMapper
        {
                public DALLocationMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>94e200884c873ea36f2c8a22a5e65587</Hash>
</Codenesium>*/