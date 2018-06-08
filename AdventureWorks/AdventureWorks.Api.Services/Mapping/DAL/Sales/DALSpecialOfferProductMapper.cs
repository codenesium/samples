using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSpecialOfferProductMapper: DALAbstractSpecialOfferProductMapper, IDALSpecialOfferProductMapper
        {
                public DALSpecialOfferProductMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5babff771c2cedd605cb5e5cde6aec1f</Hash>
</Codenesium>*/