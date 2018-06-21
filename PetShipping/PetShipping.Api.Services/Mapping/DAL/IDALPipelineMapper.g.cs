using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineMapper
        {
                Pipeline MapBOToEF(
                        BOPipeline bo);

                BOPipeline MapEFToBO(
                        Pipeline efPipeline);

                List<BOPipeline> MapEFToBO(
                        List<Pipeline> records);
        }
}

/*<Codenesium>
    <Hash>ec0f23f3b1e790ce3c71b07304a7a482</Hash>
</Codenesium>*/