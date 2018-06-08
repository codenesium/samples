using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>d70951e90070ddc41a92c17ae19e4418</Hash>
</Codenesium>*/