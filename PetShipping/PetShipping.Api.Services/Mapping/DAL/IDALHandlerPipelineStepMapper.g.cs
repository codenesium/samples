using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>eb679920e81bf5e66fab98a0fd7d8765</Hash>
</Codenesium>*/