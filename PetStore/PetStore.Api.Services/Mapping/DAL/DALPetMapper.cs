using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class DALPetMapper: DALAbstractPetMapper, IDALPetMapper
        {
                public DALPetMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa5916aa545510b4687fb9fd48c4b297</Hash>
</Codenesium>*/