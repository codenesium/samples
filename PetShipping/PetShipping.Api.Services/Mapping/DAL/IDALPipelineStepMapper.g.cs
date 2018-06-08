using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>ce8614af13432bd9c124c2c225fcbde0</Hash>
</Codenesium>*/