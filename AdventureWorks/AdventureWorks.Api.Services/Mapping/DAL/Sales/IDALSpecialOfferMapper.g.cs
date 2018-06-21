using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>b509527cc4fd348f663fc1ba121e83ed</Hash>
</Codenesium>*/