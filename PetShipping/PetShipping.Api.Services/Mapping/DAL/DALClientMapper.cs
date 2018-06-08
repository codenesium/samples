using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALClientMapper: DALAbstractClientMapper, IDALClientMapper
        {
                public DALClientMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>052d1c636fcf5e79b395e6d83cf340d9</Hash>
</Codenesium>*/