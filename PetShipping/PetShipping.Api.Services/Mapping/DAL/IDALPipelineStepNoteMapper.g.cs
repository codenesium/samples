using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALPipelineStepNoteMapper
        {
                PipelineStepNote MapBOToEF(
                        BOPipelineStepNote bo);

                BOPipelineStepNote MapEFToBO(
                        PipelineStepNote efPipelineStepNote);

                List<BOPipelineStepNote> MapEFToBO(
                        List<PipelineStepNote> records);
        }
}

/*<Codenesium>
    <Hash>cd83d4e8fc08dd11ddeb8bd1759d35cd</Hash>
</Codenesium>*/