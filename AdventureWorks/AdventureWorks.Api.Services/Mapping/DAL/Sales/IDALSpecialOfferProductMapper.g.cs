using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSpecialOfferProductMapper
        {
                SpecialOfferProduct MapBOToEF(
                        BOSpecialOfferProduct bo);

                BOSpecialOfferProduct MapEFToBO(
                        SpecialOfferProduct efSpecialOfferProduct);

                List<BOSpecialOfferProduct> MapEFToBO(
                        List<SpecialOfferProduct> records);
        }
}

/*<Codenesium>
    <Hash>707c8e542ab1e8799bb2b96376aaef0f</Hash>
</Codenesium>*/