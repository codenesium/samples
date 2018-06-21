using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALPetMapper : DALAbstractPetMapper, IDALPetMapper
        {
                public DALPetMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b7781b400c0db51a8a12d954ba43d515</Hash>
</Codenesium>*/