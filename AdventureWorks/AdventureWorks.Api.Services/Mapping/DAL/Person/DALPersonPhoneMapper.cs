using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALPersonPhoneMapper : DALAbstractPersonPhoneMapper, IDALPersonPhoneMapper
        {
                public DALPersonPhoneMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>729326440d806be6c6d5eb262e68d656</Hash>
</Codenesium>*/