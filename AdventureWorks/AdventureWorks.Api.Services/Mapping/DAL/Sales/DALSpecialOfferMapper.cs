using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSpecialOfferMapper: DALAbstractSpecialOfferMapper, IDALSpecialOfferMapper
        {
                public DALSpecialOfferMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6b719c16c4dcb399a3c00cf989f56189</Hash>
</Codenesium>*/