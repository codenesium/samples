using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>10c300d45e427e47173ca77f30a92837</Hash>
</Codenesium>*/