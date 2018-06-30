using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public partial class DALClientCommunicationMapper : DALAbstractClientCommunicationMapper, IDALClientCommunicationMapper
        {
                public DALClientCommunicationMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f140d68f43028b78b0fa02a09083d395</Hash>
</Codenesium>*/