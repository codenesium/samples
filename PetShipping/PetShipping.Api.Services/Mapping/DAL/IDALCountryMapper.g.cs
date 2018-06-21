using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALCountryMapper
        {
                Country MapBOToEF(
                        BOCountry bo);

                BOCountry MapEFToBO(
                        Country efCountry);

                List<BOCountry> MapEFToBO(
                        List<Country> records);
        }
}

/*<Codenesium>
    <Hash>c37add400dac6d33e740b6d7c6d17c02</Hash>
</Codenesium>*/