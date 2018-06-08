using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>8694cd136ce9a23d21419df05cbb5cac</Hash>
</Codenesium>*/