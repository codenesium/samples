using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALClientCommunicationMapper : DALAbstractClientCommunicationMapper, IDALClientCommunicationMapper
        {
                public DALClientCommunicationMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c534ab5f34a2fee4e9903cbc7c501ade</Hash>
</Codenesium>*/