using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPasswordMapper : DALAbstractPasswordMapper, IDALPasswordMapper
        {
                public DALPasswordMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a7e735f2f011c0b25d72313f322add1f</Hash>
</Codenesium>*/