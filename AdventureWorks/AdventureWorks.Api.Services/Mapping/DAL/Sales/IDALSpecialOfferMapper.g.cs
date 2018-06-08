using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSpecialOfferMapper
        {
                SpecialOffer MapBOToEF(
                        BOSpecialOffer bo);

                BOSpecialOffer MapEFToBO(
                        SpecialOffer efSpecialOffer);

                List<BOSpecialOffer> MapEFToBO(
                        List<SpecialOffer> records);
        }
}

/*<Codenesium>
    <Hash>bbb509086c07a901f27cfa03e95da9ff</Hash>
</Codenesium>*/