using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStepDestinationMapper
        {
                PipelineStepDestination MapBOToEF(
                        BOPipelineStepDestination bo);

                BOPipelineStepDestination MapEFToBO(
                        PipelineStepDestination efPipelineStepDestination);

                List<BOPipelineStepDestination> MapEFToBO(
                        List<PipelineStepDestination> records);
        }
}

/*<Codenesium>
    <Hash>f77b374b4f283ea89015deda8687b638</Hash>
</Codenesium>*/