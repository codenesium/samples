using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepNoteRepository : AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
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
    <Hash>3298fb3ae0fc2fe76df86c2c25f120ae</Hash>
</Codenesium>*/