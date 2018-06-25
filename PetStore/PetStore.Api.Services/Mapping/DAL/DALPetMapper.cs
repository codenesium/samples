using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public partial class DALPetMapper : DALAbstractPetMapper, IDALPetMapper
        {
                public DALPetMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>4d9aebb1e2de16ea73d8799ebd07b80f</Hash>
</Codenesium>*/