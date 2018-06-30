using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f54c94bbdb41c00d0b8499dca9dccc8d</Hash>
</Codenesium>*/