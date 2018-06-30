using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALSpeciesMapper
        {
                Species MapBOToEF(
                        BOSpecies bo);

                BOSpecies MapEFToBO(
                        Species efSpecies);

                List<BOSpecies> MapEFToBO(
                        List<Species> records);
        }
}

/*<Codenesium>
    <Hash>a3b8f1f51f07a1357145103c40dff998</Hash>
</Codenesium>*/