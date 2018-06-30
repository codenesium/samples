using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStepStatusMapper
        {
                PipelineStepStatus MapBOToEF(
                        BOPipelineStepStatus bo);

                BOPipelineStepStatus MapEFToBO(
                        PipelineStepStatus efPipelineStepStatus);

                List<BOPipelineStepStatus> MapEFToBO(
                        List<PipelineStepStatus> records);
        }
}

/*<Codenesium>
    <Hash>e99c67c3505445ac87f499b1fb86c294</Hash>
</Codenesium>*/