using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALCountryRequirementMapper
        {
                CountryRequirement MapBOToEF(
                        BOCountryRequirement bo);

                BOCountryRequirement MapEFToBO(
                        CountryRequirement efCountryRequirement);

                List<BOCountryRequirement> MapEFToBO(
                        List<CountryRequirement> records);
        }
}

/*<Codenesium>
    <Hash>498e5d5c4a5556bf57b52a0009cc2335</Hash>
</Codenesium>*/