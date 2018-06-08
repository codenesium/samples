using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>9ad79a0591527f7fceaae85b5d280e54</Hash>
</Codenesium>*/