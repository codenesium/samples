using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>eec90d62d068eb0a58486714dba99764</Hash>
</Codenesium>*/