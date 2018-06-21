using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>063387df74a7e1088ccae2c69cdcf40b</Hash>
</Codenesium>*/