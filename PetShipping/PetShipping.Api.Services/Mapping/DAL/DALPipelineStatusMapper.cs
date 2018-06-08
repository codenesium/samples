using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALPipelineStatusMapper: DALAbstractPipelineStatusMapper, IDALPipelineStatusMapper
        {
                public DALPipelineStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>cd7d1bf96c286cf80ae9c5f4e0ddf612</Hash>
</Codenesium>*/