using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStepMapper
        {
                PipelineStep MapBOToEF(
                        BOPipelineStep bo);

                BOPipelineStep MapEFToBO(
                        PipelineStep efPipelineStep);

                List<BOPipelineStep> MapEFToBO(
                        List<PipelineStep> records);
        }
}

/*<Codenesium>
    <Hash>04a42fcaaaf89bd7d12907175871f43d</Hash>
</Codenesium>*/