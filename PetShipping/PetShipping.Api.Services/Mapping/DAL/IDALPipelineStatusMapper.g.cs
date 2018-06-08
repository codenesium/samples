using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStatusMapper
        {
                PipelineStatus MapBOToEF(
                        BOPipelineStatus bo);

                BOPipelineStatus MapEFToBO(
                        PipelineStatus efPipelineStatus);

                List<BOPipelineStatus> MapEFToBO(
                        List<PipelineStatus> records);
        }
}

/*<Codenesium>
    <Hash>d832d44cbf78174e534a406cbf7a6b8b</Hash>
</Codenesium>*/