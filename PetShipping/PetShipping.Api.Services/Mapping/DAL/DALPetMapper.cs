using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALPetMapper: DALAbstractPetMapper, IDALPetMapper
        {
                public DALPetMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>58da072664db216901b4093e4eb86c74</Hash>
</Codenesium>*/