using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>65404e6928b147774942890137347048</Hash>
</Codenesium>*/