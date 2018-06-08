using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPersonPhoneMapper: DALAbstractPersonPhoneMapper, IDALPersonPhoneMapper
        {
                public DALPersonPhoneMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>21a834ea916efe9782b0dfe9e4da528f</Hash>
</Codenesium>*/