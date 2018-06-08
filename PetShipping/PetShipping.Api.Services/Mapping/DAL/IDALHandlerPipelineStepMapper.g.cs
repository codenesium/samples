using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALHandlerPipelineStepMapper
        {
                HandlerPipelineStep MapBOToEF(
                        BOHandlerPipelineStep bo);

                BOHandlerPipelineStep MapEFToBO(
                        HandlerPipelineStep efHandlerPipelineStep);

                List<BOHandlerPipelineStep> MapEFToBO(
                        List<HandlerPipelineStep> records);
        }
}

/*<Codenesium>
    <Hash>e1a3a256c098bb757a2523e1b802cbb2</Hash>
</Codenesium>*/