using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>80a8ce06821a8432f0e4bcde52b2cee8</Hash>
</Codenesium>*/