using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c99a0d7242b733aea049bc2f1b84692d</Hash>
</Codenesium>*/