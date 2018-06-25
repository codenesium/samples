using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public partial class DALPetMapper : DALAbstractPetMapper, IDALPetMapper
        {
                public DALPetMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>18ecd22faf9bde56357b26bc2f5b2ac2</Hash>
</Codenesium>*/