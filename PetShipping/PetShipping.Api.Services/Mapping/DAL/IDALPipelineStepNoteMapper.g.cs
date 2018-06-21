using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f44f1710717bb744797251c08b598a7e</Hash>
</Codenesium>*/