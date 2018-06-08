using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepNoteRepository: AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
        {
                public PipelineStepNoteRepository(
                        ILogger<PipelineStepNoteRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>79a55312251c2d46bd6f2df39c2ed457</Hash>
</Codenesium>*/