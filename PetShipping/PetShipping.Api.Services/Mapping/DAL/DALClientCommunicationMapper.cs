using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALClientCommunicationMapper: DALAbstractClientCommunicationMapper, IDALClientCommunicationMapper
        {
                public DALClientCommunicationMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a431048c43ed42e1f0b4246ee5580ae5</Hash>
</Codenesium>*/